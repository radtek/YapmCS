using Common;
using System;

public partial class frmDumpFile
{
    private string _dir;

    public string TargetDir
    {
        get
        {
            return _dir;
        }
    }
    public Native.Api.NativeEnums.MiniDumpType DumpOption
    {
        get
        {
            switch (this.cbOption.Text)
            {
                case "MiniDumpNormal":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpNormal;
                    }

                case "MiniDumpWithDataSegs":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithDataSegs;
                    }

                case "MiniDumpWithFullMemory":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithFullMemory;
                    }

                case "MiniDumpWithHandleData":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithHandleData;
                    }

                case "MiniDumpFilterMemory":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpFilterMemory;
                    }

                case "MiniDumpScanMemory":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpScanMemory;
                    }

                case "MiniDumpWithUnloadedModules":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithUnloadedModules;
                    }

                case "MiniDumpWithIndirectlyReferencedMemory":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithIndirectlyReferencedMemory;
                    }

                case "MiniDumpFilterModulePaths":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpFilterModulePaths;
                    }

                case "MiniDumpWithProcessThreadData":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithProcessThreadData;
                    }

                case "MiniDumpWithPrivateReadWriteMemory":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithPrivateReadWriteMemory;
                    }

                case "MiniDumpWithoutOptionalData":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithoutOptionalData;
                    }

                case "MiniDumpWithFullMemoryInfo":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithFullMemoryInfo;
                    }

                case "MiniDumpWithThreadInfo":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithThreadInfo;
                    }

                case "MiniDumpWithCodeSegs":
                    {
                        return Native.Api.NativeEnums.MiniDumpType.MiniDumpWithCodeSegs;
                    }
            }
        }
    }

    private void frmWindowsList_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdBrowse, "Select target directory");
        Misc.SetToolTip(this.txtDir, "Target directory");
        Misc.SetToolTip(this.cmdCreate, "Create the minidump now");
        Misc.SetToolTip(this.cmdExit, "Close this window");
        Misc.SetToolTip(this.cbOption, "Specifies the datas to include into the dump file");
        this.cbOption.Text = "MiniDumpNormal";
    }

    private void cmdCreate_Click(System.Object sender, System.EventArgs e)
    {
        if (System.IO.Directory.Exists(_dir))
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        else
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void cmdExit_Click(System.Object sender, System.EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void txtDir_TextChanged(System.Object sender, System.EventArgs e)
    {
        _dir = this.txtDir.Text;
    }

    private void cmdBrowse_Click(System.Object sender, System.EventArgs e)
    {
        {
            var withBlock = ChooseFolder;
            withBlock.Description = "Select target directory";
            withBlock.RootFolder = Environment.SpecialFolder.MyComputer;
            withBlock.ShowNewFolderButton = true;
            if (withBlock.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtDir.Text = withBlock.SelectedPath;
        }
    }
}
