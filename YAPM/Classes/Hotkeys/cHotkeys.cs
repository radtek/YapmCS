using Microsoft.VisualBasic;
using System;

public class cHotkeys
{

    // ========================================
    // API declarations
    // ========================================

    private const int vbKeyShift = 16;
    private const int vbKeyControl = 17;
    private const int vbKeyAlt = 18;
    private const int vbShiftMask = vbKeyShift;
    private const int vbCtrlMask = vbKeyControl;
    private const int vbAltMask = vbKeyAlt;


    // ========================================
    // Private attributes
    // ========================================
    private IntPtr hKeyHook;
    private bool boolStopHooking;              // Private !
    private Collection _col = new Collection();

    // Delegate function (function which replace the 'normal' one)
    private Native.Api.NativeFunctions.HookProcKbd myCallbackDelegate = null;


    // ========================================
    // Public properties
    // ========================================
    public Collection HotKeysCollection
    {
        get
        {
            return _col;
        }
    }
    public string[] ActionsAvailable
    {
        get
        {
            string[] s;
            s = new string[2];
            s[0] = "Kill foreground application";
            s[1] = "Exit YAPM";
            return s;
        }
    }

    // ========================================
    // Public functions
    // ========================================

    // Add a key to collection
    public bool AddHotkey(cShortcut hotkey)
    {
        string sKey = "|" + System.Convert.ToString(System.Convert.ToInt32(hotkey.Key1)) + "|" + System.Convert.ToString(System.Convert.ToInt32(hotkey.Key2)) + "|" + System.Convert.ToString(System.Convert.ToInt32(hotkey.Key3));
        try
        {
            _col.Add(Key: sKey, Item: hotkey);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    // Remove key from collection
    public bool RemoveHotKey(cShortcut hotkey)
    {
        string sKey = "|" + System.Convert.ToString(System.Convert.ToInt32(hotkey.Key1)) + "|" + System.Convert.ToString(System.Convert.ToInt32(hotkey.Key2)) + "|" + System.Convert.ToString(System.Convert.ToInt32(hotkey.Key3));
        try
        {
            _col.Remove(sKey);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public bool RemoveHotKey(string hotkey)
    {
        try
        {
            _col.Remove(hotkey);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public cHotkeys()
    {
        AttachKeyboardHook();
    }
    ~cHotkeys()
    {
        DetachKeyboardHook();
    }


    // ========================================
    // Private functions
    // ========================================

    // ========================================
    // Start hooking of keyboard
    // ========================================
    private void AttachKeyboardHook()
    {
        if (hKeyHook.IsNull())
        {

            // Initialize our delegate
            this.myCallbackDelegate = new Native.Api.NativeFunctions.HookProcKbd(this.KeyboardFilter());

            hKeyHook = Native.Api.NativeFunctions.SetWindowsHookEx(Native.Api.NativeEnums.HookType.KeyboardLowLevel, this.myCallbackDelegate, IntPtr.Zero, 0); // 0 -> all threads
            GC.KeepAlive(this.myCallbackDelegate);
        }
    }

    // ========================================
    // Stop hooking of keyboard
    // ========================================
    private void DetachKeyboardHook()
    {
        if ((hKeyHook.IsNotNull()))
        {
            Native.Api.NativeFunctions.UnhookWindowsHookEx(hKeyHook);
            hKeyHook = IntPtr.Zero;
        }
    }


    // ========================================
    // This function is called each time a key is pressed
    // ========================================
    private int KeyboardFilter(int nCode, IntPtr wParam, ref Native.Api.NativeStructs.KBDLLHookStruct lParam)
    {
        bool bAlt;
        bool bCtrl;
        bool bShift;
        object cSs;


        if (nCode == Native.Api.NativeConstants.HC_ACTION & !boolStopHooking)
        {
            bShift = (Native.Api.NativeFunctions.GetAsyncKeyState(vbKeyShift) != 0);
            bAlt = (Native.Api.NativeFunctions.GetAsyncKeyState(vbKeyAlt) != 0);
            bCtrl = (Native.Api.NativeFunctions.GetAsyncKeyState(vbKeyControl) != 0);

            // Check for each of our cShortCut if the shortcut is activated
            foreach (var cSs in _col)
            {
                cShortcut cs = (cShortcut)cSs;

                if (cs.Enabled)
                {
                    if ((cs.Key1 == cShortcut.ShorcutKeys.VK_NO_BUTTON) | (cs.Key1 == vbShiftMask & bShift) | (cs.Key1 == vbAltMask & bAlt) | (cs.Key1 == vbCtrlMask & bCtrl))
                    {

                        // Then the first of the 3 keys is pressed
                        // Check the second one
                        if ((cs.Key2 == cShortcut.ShorcutKeys.VK_NO_BUTTON) | (cs.Key2 == vbShiftMask & bShift) | (cs.Key2 == vbAltMask & bAlt) | (cs.Key2 == vbCtrlMask & bCtrl))
                        {

                            // The the second of the 3 keys is pressed
                            // Check this last one
                            if ((lParam.vkCode == cs.Key3))
                            {

                                // The third of the 3 keys is pressed
                                boolStopHooking = true;                      // We stop hooking shortcuts

                                // Process emergency action
                                cs.RaiseAction();

                                boolStopHooking = false;                     // Now we can hook another shortcuts
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Next hook
        KeyboardFilter = Native.Api.NativeFunctions.CallNextHookEx(hKeyHook, nCode, wParam, lParam);
    }
}

