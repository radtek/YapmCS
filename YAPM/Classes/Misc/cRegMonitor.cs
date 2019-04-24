using Common;
using System;
using System.Threading;

public class cRegMonitor
{

    // Definition of a key
    public struct KeyDefinition
    {
        public string name;
    }

    // Event to raise
    public event KeyAddedEventHandler KeyAdded;

    public delegate void KeyAddedEventHandler(KeyDefinition key);

    public event KeyDeletedEventHandler KeyDeleted;

    public delegate void KeyDeletedEventHandler(KeyDefinition key);

    private IntPtr _hEvent;
    private IntPtr _hKey;
    private Native.Api.NativeEnums.KeyMonitoringType _type;
    private string[] _keys;
    private string[] _ss;
    private string _path;
    private Native.Api.NativeEnums.KeyType _kt;
    public Thread _t;

    // Constructor
    public cRegMonitor(Native.Api.NativeEnums.KeyType KeyType, string path, Native.Api.NativeEnums.KeyMonitoringType monType)
    {

        // Launch event waiting
        _kt = KeyType;
        _type = monType;
        _path = path;
        _t = new Thread(ThreadEvent);
        _t.IsBackground = true;                  // Thread will close when app close
        _t.Priority = ThreadPriority.Highest;
        _t.Start();
    }

    ~cRegMonitor()
    {
        Native.Api.NativeFunctions.RegCloseKey(_hKey);
        Native.Api.NativeFunctions.CloseHandle(_hEvent);
    }

    // Process thread
    private void ThreadEvent()
    {

        // Create an event
        while (true)
        {
            Native.Api.NativeFunctions.RegOpenKeyEx((IntPtr)_kt, _path, 0, Native.Api.NativeConstants.KEY_NOTIFY, ref _hKey);

            _hEvent = Native.Api.NativeFunctions.CreateEvent((IntPtr)0, true, false, null);

            // Set monitoring
            Native.Api.NativeFunctions.RegNotifyChangeKeyValue(_hKey, true, _type, _hEvent, true);

            // Get current keys
            _keys = getKeys(_path);

            // Wait for modification
            if (Native.Api.NativeFunctions.WaitForSingleObject(_hEvent, Native.Api.NativeConstants.WAIT_INFINITE) == Native.Api.NativeEnums.WaitResult.Failed)
            {
            }
            else
            {
                // Changed
                // Trace.WriteLine("Detected a change")
                _ss = getKeys(_path);
                keysChanged();
            }
            Native.Api.NativeFunctions.CloseHandle(_hEvent);
            Native.Api.NativeFunctions.RegCloseKey(_hKey);
        }
    }

    private void keysChanged()
    {

        // Compare with old list and get differences
        string s = "";

        try
        {

            // Deleted keys
            foreach (var s in _keys)
            {
                string s2 = "";
                bool b = false;
                foreach (var s2 in _ss)
                {
                    if (s2 == s)
                    {
                        b = true;
                        break;
                    }
                }
                if (!(b))
                {
                    // s deleted
                    KeyDefinition k;
                    k.name = s;
                    // Trace.WriteLine("Key deleted")
                    KeyDeleted?.Invoke(k);
                }
            }

            // New keys
            foreach (var s in _ss)
            {
                string s2 = "";
                bool b = false;
                foreach (var s2 in _keys)
                {
                    if (s2 == s)
                    {
                        b = true;
                        break;
                    }
                }
                if (!(b))
                {
                    // s added
                    KeyDefinition k;
                    k.name = s;
                    // Trace.WriteLine("Key added")
                    KeyAdded?.Invoke(k);
                }
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    // Get list of all subkeys from registry
    public static string[] getKeys(string path)
    {
        Microsoft.Win32.RegistryKey key = My.MyProject.Computer.Registry.LocalMachine.OpenSubKey(path);
        try
        {
            return key.GetSubKeyNames();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

