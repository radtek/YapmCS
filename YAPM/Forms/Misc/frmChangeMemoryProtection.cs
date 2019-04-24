using Common;

public partial class frmChangeMemoryProtection
{

    // AccessDenied = 0
    // Execute = &H10
    // ExecuteRead = &H20
    // ExecuteReadWrite = &H40
    // ExecuteWriteCopy = &H80
    // NoAccess = &H1
    // [ReadOnly] = &H2
    // ReadWrite = &H4
    // WriteCopy = &H8
    // Guard = &H100
    // NoCache = &H200
    // WriteCombine = &H400

    public Native.Api.NativeEnums.MemoryProtectionType ProtectionType
    {
        set
        {
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.Execute) == Native.Api.NativeEnums.MemoryProtectionType.Execute)
                this.optE.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.ExecuteRead) == Native.Api.NativeEnums.MemoryProtectionType.ExecuteRead)
                this.optER.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.ExecuteReadWrite) == Native.Api.NativeEnums.MemoryProtectionType.ExecuteReadWrite)
                this.optERW.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.ExecuteWriteCopy) == Native.Api.NativeEnums.MemoryProtectionType.ExecuteWriteCopy)
                this.optEWC.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.NoAccess) == Native.Api.NativeEnums.MemoryProtectionType.NoAccess)
                this.optNA.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.ReadOnly) == Native.Api.NativeEnums.MemoryProtectionType.ReadOnly)
                this.optRO.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.ReadWrite) == Native.Api.NativeEnums.MemoryProtectionType.ReadWrite)
                this.optRW.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.WriteCopy) == Native.Api.NativeEnums.MemoryProtectionType.WriteCopy)
                this.optWC.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.Guard) == Native.Api.NativeEnums.MemoryProtectionType.Guard)
                this.chkGuard.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.NoCache) == Native.Api.NativeEnums.MemoryProtectionType.NoCache)
                this.chkNoCache.Checked = true;
            if ((value & Native.Api.NativeEnums.MemoryProtectionType.WriteCombine) == Native.Api.NativeEnums.MemoryProtectionType.WriteCombine)
                this.chkWriteCombine.Checked = true;
        }
    }

    public Native.Api.NativeEnums.MemoryProtectionType NewProtectionType
    {
        get
        {
            Native.Api.NativeEnums.MemoryProtectionType _type;

            if (this.optE.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.Execute;
            if (this.optER.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.ExecuteRead;
            if (this.optERW.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.ExecuteReadWrite;
            if (this.optEWC.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.ExecuteWriteCopy;
            if (this.optNA.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.NoAccess;
            if (this.optRO.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.ReadOnly;
            if (this.optRW.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.ReadWrite;
            if (this.optWC.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.WriteCopy;
            if (this.chkGuard.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.Guard;
            if (this.chkNoCache.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.NoCache;
            if (this.chkWriteCombine.Checked)
                _type = _type | Native.Api.NativeEnums.MemoryProtectionType.WriteCombine;

            return _type;
        }
    }

    private void frmWindowsList_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdChangeProtection, "Change protection type now");
        Misc.SetToolTip(this.cmdExit, "Close this window");
        Misc.SetToolTip(this.optE, "Enables execute access to the committed region of pages. An attempt to read from or write to the committed region results in an access violation.");
        Misc.SetToolTip(this.optER, "Enables execute, read-only, or copy-on-write access to the committed region of pages. An attempt to write to the committed region results in an access violation.");
        Misc.SetToolTip(this.optERW, "Enables execute, read-only, read/write, or copy-on-write access to the committed region of pages.");
        Misc.SetToolTip(this.optEWC, "Enables execute, read-only, or copy-on-write access to the committed region of image file code pages. This value is equivalent to PAGE_EXECUTE_READ.");
        Misc.SetToolTip(this.optNA, "Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation exception, called a general protection (GP) fault.");
        Misc.SetToolTip(this.optRO, "Enables read-only or copy-on-write access to the committed region of pages. An attempt to write to the committed region results in an access violation. If the system differentiates between read-only access and execute access, an attempt to execute code in the committed region results in an access violation.");
        Misc.SetToolTip(this.optRW, "Enables read-only, read/write, or copy-on-write access to the committed region of pages.");
        Misc.SetToolTip(this.optWC, "Enables read-only or copy-on-write access to the committed region of pages. This value is equivalent to PAGE_READONLY.");
        Misc.SetToolTip(this.chkGuard, "Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status. Guard pages thus act as a one-time access alarm. For more information, see Creating Guard Pages.");
        Misc.SetToolTip(this.chkNoCache, "Sets all pages to be non-cachable. Applications should not use this attribute except when explicitly required for a device. Using the interlocked functions with memory that is mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.");
        Misc.SetToolTip(this.chkWriteCombine, "Sets all pages to be write-combined. Applications should not use this attribute except when explicitly required for a device. Using the interlocked functions with memory that is mapped as write-combined can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.");
    }

    private void cmdCreate_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void cmdExit_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }


    // This is NOT possible to combile all flags together with all protection types
    // See http://msdn.microsoft.com/en-us/library/aa366786(VS.85).aspx
    // for details about what is permitted and what is not
    private void optNA_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        this.chkGuard.Enabled = (this.optNA.Checked == false);
        this.chkNoCache.Enabled = (this.optNA.Checked == false);
        this.chkWriteCombine.Enabled = (this.optNA.Checked == false);
        if (this.optNA.Checked)
        {
            this.chkGuard.Checked = false;
            this.chkNoCache.Checked = false;
            this.chkWriteCombine.Checked = false;
        }
    }
    private void chkGuard_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (chkGuard.Enabled)
        {
            this.chkNoCache.Enabled = (this.chkGuard.Checked == false);
            this.chkWriteCombine.Enabled = (this.chkGuard.Checked == false);
            if (this.chkGuard.Checked)
            {
                this.chkNoCache.Checked = false;
                this.chkWriteCombine.Checked = false;
            }
        }
    }
    private void chkNoCache_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (chkNoCache.Enabled)
        {
            this.chkWriteCombine.Enabled = (this.chkNoCache.Checked == false);
            this.chkGuard.Enabled = (this.chkNoCache.Checked == false);
            if (this.chkNoCache.Checked)
            {
                this.chkWriteCombine.Checked = false;
                this.chkGuard.Checked = false;
            }
        }
    }
    private void chkWriteCombine_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (chkWriteCombine.Enabled)
        {
            this.chkNoCache.Enabled = (this.chkWriteCombine.Checked == false);
            this.chkGuard.Enabled = (this.chkWriteCombine.Checked == false);
            if (this.chkWriteCombine.Checked)
            {
                this.chkNoCache.Checked = false;
                this.chkGuard.Checked = false;
            }
        }
    }


    private void linkMSDN_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        cFile.ShellOpenFile("http://msdn.microsoft.com/en-us/library/aa366786(VS.85).aspx", this.Handle);
    }
}
