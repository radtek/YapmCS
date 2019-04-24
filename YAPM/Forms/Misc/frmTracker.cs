using Common;

public partial class frmTracker
{
    private void frmTracker_Load(object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdGoBug, "Navigate to the bug tracker");
        Misc.SetToolTip(this.cmdGoFeed, "Send a feed back");
        Misc.SetToolTip(this.cmdGoSug, "Navigate to the forums of YAPM on sourceforge.net");

        string s = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1036\deflangfe1036\deftab708{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}}";
        s += @"{\colortbl ;\red255\green0\blue0;\red0\green0\blue255;}";
        s += @"{\*\generator Msftedit 5.41.21.2508;}\viewkind4\uc1\pard\lang1033\f0\fs22 If you have any suggestion or question or idea of improvement/new feature about\i  \ul Yet Another (remote) Process Monitor\ulnone\i0 , please feel free to contact me (use one of the method below: tracker, forum, email).\par";
        s += @"\par";
        s += @"\cf1 If you find a bug, \cf0\b PLEASE\b0  use the sourceforge.net tracker and specify, if possible (it would be very helpful for me) these informations :\par";
        s += @"\pard\fi-360\li720 -\tab the version of YAPM you are using\par";
        s += @"-\tab the operating system you are using\par";
        s += @"-\tab\b a description of the bug you found \par";
        s += @"\b0 -\tab\b how to reproduce it\b0  (if possible, it would be so helpful !)\par";
        s += @"\pard\par";
        s += @" Any feed back is appreciated !\par";
        s += "}";
        this.rtb.Rtf = s;
    }

    private void cmdGoBug_Click(System.Object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile(this.txtBug.Text, this.Handle);
    }

    private void cmdGoSug_Click(System.Object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile(this.txtSug.Text, this.Handle);
    }

    private void cmdGoFeed_Click(System.Object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile("mailto:YetAnotherProcessMonitor@gmail.com", this.Handle);
    }
}
