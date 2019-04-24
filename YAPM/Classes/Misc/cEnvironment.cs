// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// =======================================================


// YAPM is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// YAPM is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with YAPM; if not, see http://www.gnu.org/licenses/.


using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;
using System.Runtime.InteropServices;
using Native.Api;

public class cEnvironment
{
    public enum PrivilegeToRequest
    {
        ShutdownPrivilege,
        DebugPrivilege
    }

    // Public properties

    // Return true if the application is already running
    public static bool IsAlreadyRunning
    {
        get
        {
            IntPtr hMap;
            IntPtr pMem;
            int hPid;

            const string FILE_NAME = "YAPM-instanceCheck";

            // # Nous tentons ici d'acceder au mappage (précedemment créé ?)
            hMap = NativeFunctions.OpenFileMapping(NativeConstants.FILE_MAP_READ, false, FILE_NAME);
            if (hMap.IsNotNull())
            {
                // # L'application est déjà lancée.
                pMem = NativeFunctions.MapViewOfFile(hMap, NativeEnums.FileMapAccess.FileMapRead, 0, 0, 0);
                if (pMem.IsNotNull())
                {
                    // # On récupère le handle vers la précédente fenêtre
                    hPid = Marshal.ReadInt32(pMem, 0);
                    if (hPid != 0)
                    {
                        // # On active l'instance précedente
                        try
                        {
                            Interaction.AppActivate(hPid);
                        }
                        catch (Exception ex)
                        {
                            Misc.ShowDebugError(ex);
                        }
                    }
                    NativeFunctions.UnmapViewOfFile(pMem);
                }
                // # On libère le handle hmap
                NativeFunctions.CloseHandle(hMap);
                // # et on prévient l'appelant que l'application avait dejà été lancée.
                return true;
            }
            else
            {
                // # Nous sommes dans la première instance de l'application.
                // # Nous allons laisser une marque en mémoire, pour l'indiquer
                hMap = NativeFunctions.CreateFileMapping(NativeConstants.InvalidHandleValue, IntPtr.Zero, NativeEnums.FileMapProtection.PageReadWrite, 0, 4, FILE_NAME);
                if (hMap.IsNotNull())
                {
                    // # On ouvre le 'fichier' en écriture
                    pMem = NativeFunctions.MapViewOfFile(hMap, NativeEnums.FileMapAccess.FileMapWrite, 0, 0, 0);
                    if (pMem.IsNotNull())
                    {
                        // # On y écrit l'ID du process courant
                        Marshal.WriteInt32(pMem, 0, NativeFunctions.GetCurrentProcessId());
                        NativeFunctions.UnmapViewOfFile(pMem);
                    }
                }
            }

            return false;
        }
    }

    public static bool IsAdmin
    {
        get
        {
            return My.MyProject.User.IsAuthenticated && My.MyProject.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator);
        }
    }

    public static bool Is32Bits
    {
        get
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(IntPtr.Zero) == 4;
        }
    }

    public static bool IsFramework2OrAbove
    {
        get
        {
            return Environment.Version.Major >= 2;
        }
    }

    public static bool IsWindowsVistaOrAbove
    {
        get
        {
            return (Environment.OSVersion.Platform == PlatformID.Win32NT) & (Environment.OSVersion.Version.Major >= 6);
        }
    }

    public static bool IsWindows7
    {
        get
        {
            return (Environment.OSVersion.Platform == PlatformID.Win32NT) & (Environment.OSVersion.Version.Major == 6 & Environment.OSVersion.Version.Minor == 1);
        }
    }



    public static bool SupportsTaskDialog
    {
        get
        {
            return IsWindowsVistaOrAbove;
        }
    }

    public static bool SupportsUac
    {
        get
        {
            return IsWindowsVistaOrAbove;
        }
    }

    public static bool SupportsGetNextThreadProcessFunctions
    {
        get
        {
            return IsWindowsVistaOrAbove;
        }
    }

    public static bool SupportsGetThreadIdFunction
    {
        get
        {
            return IsWindowsVistaOrAbove;
        }
    }

    public static bool SupportsQueryFullProcessImageNameFunction
    {
        get
        {
            return IsWindowsVistaOrAbove;
        }
    }

    public static bool SupportsMinRights
    {
        get
        {
            return IsWindowsVistaOrAbove;
        }
    }


    // Retrieve elevation type
    public static Enums.ElevationType GetElevationType
    {
        get
        {
            ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
            Static retrieved As Boolean = False

 */
            ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
            Static valRetrieved As Enums.ElevationType

 */
            if (retrieved)
                return valRetrieved;
            else
            {
                IntPtr hTok;
                IntPtr hProc = Native.Objects.Process.GetProcessHandleById(Process.GetCurrentProcess().Id, Native.Security.ProcessAccess.QueryInformation);
                if (hProc.IsNotNull())
                {
                }
                NativeFunctions.OpenProcessToken(hProc, Native.Security.TokenAccess.Query, out hTok);
                NativeFunctions.CloseHandle(hProc);

                int value;
                int ret;

                // Get tokeninfo length
                NativeFunctions.GetTokenInformation(hTok, NativeEnums.TokenInformationClass.TokenElevationType, IntPtr.Zero, 0, ref ret);
                IntPtr TokenInformation = Marshal.AllocHGlobal(ret);
                // Get token information
                NativeFunctions.GetTokenInformation(hTok, NativeEnums.TokenInformationClass.TokenElevationType, TokenInformation, ret, ref 0);
                // Get a valid structure
                value = Marshal.ReadInt32(TokenInformation, 0);
                Marshal.FreeHGlobal(TokenInformation);
                valRetrieved = (Enums.ElevationType)value;

                NativeFunctions.CloseHandle(hTok);

                if (valRetrieved == Enums.ElevationType.Default)
                {
                    if (cEnvironment.IsAdmin == false)
                        valRetrieved = Enums.ElevationType.Limited;
                    else
                        valRetrieved = Enums.ElevationType.Full;
                }

                retrieved = true;
                return valRetrieved;
            }
        }
    }

    // Has YAPM SeDebugPrivilege ?
    public static bool HasYAPMDebugPrivilege()
    {
        NativeEnums.SePrivilegeAttributes res;
        Native.Objects.Token.GetPrivilegeStatusByProcessId(Process.GetCurrentProcess().Id, "SeDebugPrivilege", ref res);
        return (res == NativeEnums.SePrivilegeAttributes.Enabled);
    }

    // Request a privilege
    public static void RequestPrivilege(PrivilegeToRequest privilege)
    {
        // TOCHANGE : should be more generic
        switch (privilege)
        {
            case PrivilegeToRequest.DebugPrivilege:
                {
                    Native.Objects.Token.SetPrivilegeStatusByProcessId(System.Diagnostics.Process.GetCurrentProcess().Id, "SeDebugPrivilege", NativeEnums.SePrivilegeAttributes.Enabled);
                    break;
                }

            case PrivilegeToRequest.ShutdownPrivilege:
                {
                    Native.Objects.Token.SetPrivilegeStatusByProcessId(System.Diagnostics.Process.GetCurrentProcess().Id, "SeShutdownPrivilege", NativeEnums.SePrivilegeAttributes.Enabled);
                    break;
                }
        }
    }

    // Restart YAPM elevated
    public static void RestartElevated()
    {
        NativeStructs.ShellExecuteInfo startInfo = new NativeStructs.ShellExecuteInfo();
        {
            var withBlock = startInfo;
            withBlock.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(startInfo);
            withBlock.hwnd = Program._frmMain.Handle;
            withBlock.lpFile = Application.ExecutablePath;
            withBlock.lpParameters = Program.PARAM_DO_NOT_CHECK_PREV_INSTANCE;
            withBlock.lpVerb = "runas";
            withBlock.nShow = NativeEnums.ShowWindowType.ShowNormal;
        }

        try
        {
            if (NativeFunctions.ShellExecuteEx(ref startInfo))
            {
                // Then the new process has started -> 
                // - we hide tray icon
                // - we brutaly terminate this instance
                // - new instance will start
                Program._frmMain.Tray.Visible = false;
                NativeFunctions.ExitProcess(0);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }


    // Return a bitmap containing the UAC shield.
    // Got this code here : http://www.vb-helper.com/howto_2008_uac_shield.html
    // But this is not the best way to do it...
    public static void AddShieldToButton(Button btn)
    {
        const Int32 BCM_SETSHIELD = 0x160;

        btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
        NativeFunctions.SendMessage(btn.Handle, BCM_SETSHIELD, IntPtr.Zero, NativeConstants.InvalidHandleValue);
    }
    public static Bitmap GetUacShieldImage()
    {
        ;/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
   в ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__20.MoveNext()
   в System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
   в Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
   в ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(IEnumerable`1 modifiers, TokenContext context, Boolean isVariableOrConst, Boolean isConstructor)
   в ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
   в Microsoft.CodeAnalysis.VisualBasic.Syntax.LocalDeclarationStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   в Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   в ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input: 
        Static shield_bm As Bitmap = Nothing

 */
        if (shield_bm == null)
        {
            const int WID = 50;
            const int HGT = 50;
            const int MARGIN = 4;

            // Make the button. For some reason, it must
            // have text or the UAC shield won't appear.
            Button btn = new Button();
            btn.Text = " ";
            btn.Size = new System.Drawing.Size(WID, HGT);
            AddShieldToButton(btn);

            // Draw the button onto a bitmap.
            Bitmap bm = new Bitmap(WID, HGT);
            btn.Refresh();
            btn.DrawToBitmap(bm, new Rectangle(0, 0, WID, HGT));

            // Find the part containing the shield.
            int min_x = WID;
            int max_x = 0;
            int min_y = WID;
            int max_y = 0;

            // Fill on the left.
            for (int y = MARGIN; y <= HGT - MARGIN - 1; y++)
            {
                // Get the leftmost pixel's color.
                Color target_color = bm.GetPixel(MARGIN, y);

                // Fill in with this color as long as we see the
                // target.
                for (int x = MARGIN; x <= WID - MARGIN - 1; x++)
                {
                    // See if this pixel is part of the shield.
                    if (bm.GetPixel(x, y).Equals(target_color))
                        // It's not part of the shield.
                        // Clear the pixel.
                        bm.SetPixel(x, y, Color.Transparent);
                    else
                    {
                        // It's part of the shield.
                        if (min_y > y)
                            min_y = y;
                        if (min_x > x)
                            min_x = x;
                        if (max_y < y)
                            max_y = y;
                        if (max_x < x)
                            max_x = x;
                    }
                }
            }

            // Clip out the shield part.
            int shield_wid = max_x - min_x + 1;
            int shield_hgt = max_y - min_y + 1;
            shield_bm = new Bitmap(shield_wid, shield_hgt);
            Graphics shield_gr = Graphics.FromImage(shield_bm);
            shield_gr.DrawImage(bm, 0, 0, new Rectangle(min_x, min_y, shield_wid, shield_hgt), GraphicsUnit.Pixel);
        }

        return shield_bm;
    }
}

