using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System;
using Microsoft.Samples;

public partial class frmSaveReport
{
    private string _repType;
    private string _path;

    public string ReportType
    {
        get
        {
            return _repType;
        }
        set
        {
            _repType = value;
        }
    }
    public string ReportPath
    {
        get
        {
            return _path;
        }
        set
        {
            _path = value;
        }
    }


    // Public functions to save reports
    public void SaveReportLog()
    {
        Program._frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt";
        Program._frmMain.saveDial.Title = "Save report";
        try
        {
            if (Program._frmMain.saveDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string s = Program._frmMain.saveDial.FileName;
                if (Strings.Len(s) > 0)
                {
                    // Create file report
                    string c = Constants.vbNullString;

                    this.ReportPath = s;
                    this.pgb.Maximum = Program.Log.LineCount;

                    if (s.Substring(s.Length - 3, 3).ToLower() == "txt")
                    {
                        System.IO.StreamWriter stream = new System.IO.StreamWriter(s, false);
                        // txt
                        ListViewItem it;
                        int x = 0;
                        foreach (var it in Program.Log.Items)
                        {
                            c = "Date : " + it.Text;
                            c += Constants.vbTab + "Event : " + it.SubItems[1].Text;
                            c += Constants.vbNewLine;
                            stream.Write(c);
                            x += 1;
                            UpdateProgress(x);
                        }
                        c = System.Convert.ToString(Program.Log.LineCount) + " result(s)";
                        stream.Write(c);
                        stream.Close();
                    }
                    else
                    {
                        // HTML
                        cHTML.HtmlColumnStructure[] col = new cHTML.HtmlColumnStructure[2];
                        col[0].sizePercent = 30;
                        col[0].title = "Date";
                        col[1].sizePercent = 70;
                        col[1].title = "Event";
                        string title = "Log : " + System.Convert.ToString(Program.Log.LineCount) + " item(s)";
                        cHTML _html = new cHTML(col, s, title);

                        ListViewItem it;
                        int x = 0;
                        foreach (var it in Program.Log.Items)
                        {
                            string[] _lin = new string[2];
                            _lin[0] = it.Text;
                            _lin[1] = it.SubItems[1].Text;
                            _html.AppendLine(_lin);
                            x += 1;
                            UpdateProgress(x);
                        }

                        _html.ExportHTML();
                    }

                    ReportSaved("log");
                }
            }
        }
        catch (Exception ex)
        {
            this.ReportFailed(ex);
        }
        this.cmdGO.Enabled = true;
    }
    public void SaveReportServices()
    {
        Program._frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt";
        Program._frmMain.saveDial.Title = "Save report";
        try
        {
            if (Program._frmMain.saveDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string s = Program._frmMain.saveDial.FileName;
                if (Strings.Len(s) > 0)
                {
                    // Create file report
                    string c = Constants.vbNullString;

                    this.ReportPath = s;

                    this.pgb.Maximum = Program._frmMain.lvServices.Items.Count;

                    if (s.Substring(s.Length - 3, 3).ToLower() == "txt")
                    {
                        System.IO.StreamWriter stream = new System.IO.StreamWriter(s, false);
                        // txt
                        int x = 0;
                        foreach (cService cm in Program._frmMain.lvServices.GetAllItems())
                        {
                            try
                            {
                                // Try to access to the service (avoid to write lines if service
                                // is deleted)
                                string suseless = cm.Infos.LoadOrderGroup;    // TOCHANGE

                                c += "Name" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.Name + Constants.vbNewLine;
                                c += "Common name" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.DisplayName + Constants.vbNewLine;
                                c += "Path" + Constants.vbTab + Constants.vbTab;
                                c += cm.GetInformation("ImagePath") + Constants.vbNewLine;
                                c += "ObjectName" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.ObjectName + Constants.vbNewLine;
                                c += "State" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.State.ToString() + Constants.vbNewLine;
                                c += "Startup" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.StartType.ToString() + Constants.vbNewLine + Constants.vbNewLine + Constants.vbNewLine;
                            }
                            catch (Exception ex)
                            {
                            }

                            stream.Write(c);

                            x += 1;
                            UpdateProgress(x);
                        }
                        c = System.Convert.ToString(Program._frmMain.lvServices.Items.Count) + " service(s)";
                        stream.Write(c);
                        stream.Close();
                    }
                    else
                    {
                        // HTML
                        string title = System.Convert.ToString(Program._frmMain.lvServices.Items.Count) + " service(s)";
                        cHTML2 _html = new cHTML2(s, title, 25);

                        int x = 0;
                        foreach (cService cm in Program._frmMain.lvServices.GetAllItems())
                        {
                            try
                            {
                                // Try to access to the service (avoid to write lines if service
                                // is deleted)
                                string suseless = cm.Infos.LoadOrderGroup;

                                _html.AppendTitleLine(cm.Infos.Name);
                                string[] _lin = new string[2];
                                _lin[0] = "Name";
                                _lin[1] = cm.Infos.Name;
                                _html.AppendLine(_lin);
                                _lin[0] = "Common name";
                                _lin[1] = cm.Infos.DisplayName;
                                _html.AppendLine(_lin);
                                _lin[0] = "Path";
                                _lin[1] = cm.GetInformation("ImagePath");
                                _html.AppendLine(_lin);
                                _lin[0] = "ObjectName";
                                _lin[1] = cm.Infos.ObjectName;
                                _html.AppendLine(_lin);
                                _lin[0] = "State";
                                _lin[1] = cm.Infos.State.ToString();
                                _html.AppendLine(_lin);
                                _lin[0] = "Startup";
                                _lin[1] = cm.Infos.StartType.ToString();
                                _html.AppendLine(_lin);

                                x += 1;
                                UpdateProgress(x);
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        _html.ExportHTML();
                    }

                    ReportSaved("services");
                }
            }
        }
        catch (Exception ex)
        {
            this.ReportFailed(ex);
        }
        this.cmdGO.Enabled = true;
    }
    public void SaveReportWindows()
    {
    }
    public void SaveReportThreads()
    {
    }
    public void SaveReportHandles()
    {
    }
    public void SaveReportModules()
    {
    }
    public void SaveReportSearch()
    {
        Program._frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt";
        Program._frmMain.saveDial.Title = "Save report";
        try
        {
            if (Program._frmMain.saveDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string s = Program._frmMain.saveDial.FileName;
                if (Strings.Len(s) > 0)
                {
                    // Create file report
                    string c = Constants.vbNullString;

                    this.ReportPath = s;
                    this.pgb.Maximum = Program._frmMain.lvSearchResults.Items.Count;

                    if (s.Substring(s.Length - 3, 3).ToLower() == "txt")
                    {
                        System.IO.StreamWriter stream = new System.IO.StreamWriter(s, false);
                        // txt
                        ListViewItem it;
                        int x = 0;
                        foreach (var it in Program._frmMain.lvSearchResults.Items)
                        {
                            c = "Type : " + it.Text;
                            c += "  Result : " + it.SubItems[1].Text;
                            c += "  Field : " + it.SubItems[2].Text + Constants.vbNewLine;
                            stream.Write(c);
                            x += 1;
                            UpdateProgress(x);
                        }
                        c = System.Convert.ToString(Program._frmMain.lvSearchResults.Items.Count) + " result(s)";
                        stream.Write(c);
                        stream.Close();
                    }
                    else
                    {
                        // HTML
                        cHTML.HtmlColumnStructure[] col = new cHTML.HtmlColumnStructure[3];
                        col[0].sizePercent = 22;
                        col[0].title = "Type";
                        col[1].sizePercent = 50;
                        col[1].title = "Result";
                        col[2].sizePercent = 28;
                        col[2].title = "Field";
                        string title = "Search result for '" + Program._frmMain.txtSearchString.TextBoxText + "' -- " + System.Convert.ToString(Program._frmMain.lvSearchResults.Items.Count) + " result(s)";
                        cHTML _html = new cHTML(col, s, title);

                        ListViewItem it;
                        int x = 0;
                        foreach (var it in Program._frmMain.lvSearchResults.Items)
                        {
                            string[] _lin = new string[3];
                            _lin[0] = it.Text;
                            _lin[1] = it.SubItems[1].Text;
                            _lin[2] = it.SubItems[2].Text;
                            _html.AppendLine(_lin);
                            x += 1;
                            UpdateProgress(x);
                        }

                        _html.ExportHTML();
                    }

                    ReportSaved("search");
                }
            }
        }
        catch (Exception ex)
        {
            this.ReportFailed(ex);
        }
        this.cmdGO.Enabled = true;
    }
    public void SaveReportMonitoring()
    {
        ReportSaved("monitoring");
    }

    // Report has been succesfully saved
    private void ReportSaved(string type)
    {
        // _repType = type
        this.lblProgress.Text = "Saving done.";
        this.pgb.Value = this.pgb.Maximum;
        this.cmdOK.Enabled = true;
        this.cmdOpenReport.Enabled = true;
        this.cmdGO.Enabled = false;
        this.cmdGO.Enabled = true;
        Misc.ShowMsg("Report", null, "Saved report sucessfully.", MessageBoxButtons.OK, TaskDialogIcon.ShieldOk);
    }

    // Report saving failed
    private void ReportFailed(Exception ex)
    {
        this.pgb.Value = this.pgb.Maximum;
        this.cmdOK.Enabled = true;
        this.cmdGO.Enabled = false;
        this.cmdOK.Text = "Quit";
        this.lblProgress.Text = "Saving failed";
        this.cmdOpenReport.Enabled = false;
        this.cmdGO.Enabled = true;
        Misc.ShowError(ex, "Could not save report");
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void cmdOpenReport_Click(System.Object sender, System.EventArgs e)
    {
        cFile.ShellOpenFile(this._path, this.Handle);
    }

    private void frmSaveReport_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdGO, "Save the report");
        Misc.SetToolTip(this.cmdOK, "Close this window");
        Misc.SetToolTip(this.cmdOpenReport, "Open the report which was saved");

        this.lblProgress.Text = "Waiting for save...";
        {
            var withBlock = this.pgb;
            withBlock.Maximum = 1;
            withBlock.Minimum = 0;
            withBlock.Value = 0;
        }
    }

    private void UpdateProgress(int value)
    {
        this.pgb.Value = value;
        this.lblProgress.Text = "Computing item " + System.Convert.ToString(value) + "/" + System.Convert.ToString(this.pgb.Maximum);
        Application.DoEvents();
    }

    private void cmdGO_Click(System.Object sender, System.EventArgs e)
    {
        this.cmdGO.Enabled = false;
        switch (this.ReportType)
        {
            case "services":
                {
                    this.SaveReportServices();
                    break;
                }

            case "windows":
                {
                    this.SaveReportWindows();
                    break;
                }

            case "modules":
                {
                    this.SaveReportModules();
                    break;
                }

            case "threads":
                {
                    this.SaveReportThreads();
                    break;
                }

            case "handles":
                {
                    this.SaveReportHandles();
                    break;
                }

            case "monitoring":
                {
                    this.SaveReportMonitoring();
                    break;
                }

            case "processes":
                {
                    this.SaveReportProcesses();
                    break;
                }

            case "search":
                {
                    this.SaveReportSearch();
                    break;
                }

            case "log":
                {
                    this.SaveReportLog();
                    break;
                }
        }
    }
    public void SaveReportProcesses()
    {
        Program._frmMain.saveDial.Filter = "HTML File (*.html)|*.html|Text file (*.txt)|*.txt";
        Program._frmMain.saveDial.Title = "Save report";
        try
        {
            if (Program._frmMain.saveDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string s = Program._frmMain.saveDial.FileName;
                if (Strings.Len(s) > 0)
                {
                    // Create file report
                    string c = Constants.vbNullString;

                    this.ReportPath = s;

                    this.pgb.Maximum = Program._frmMain.lvServices.Items.Count;

                    if (s.Substring(s.Length - 3, 3).ToLower() == "txt")
                    {
                        System.IO.StreamWriter stream = new System.IO.StreamWriter(s, false);
                        // txt
                        int x = 0;
                        foreach (cService cm in Program._frmMain.lvServices.GetAllItems())
                        {
                            try
                            {
                                // Try to access to the service (avoid to write lines if service
                                // is deleted)
                                string suseless = cm.Infos.LoadOrderGroup;    // TOCHANGE

                                c += "Name" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.Name + Constants.vbNewLine;
                                c += "Common name" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.DisplayName + Constants.vbNewLine;
                                c += "Path" + Constants.vbTab + Constants.vbTab;
                                c += cm.GetInformation("ImagePath") + Constants.vbNewLine;
                                c += "ObjectName" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.ObjectName + Constants.vbNewLine;
                                c += "State" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.State.ToString() + Constants.vbNewLine;
                                c += "Startup" + Constants.vbTab + Constants.vbTab;
                                c += cm.Infos.StartType.ToString() + Constants.vbNewLine + Constants.vbNewLine + Constants.vbNewLine;
                            }
                            catch (Exception ex)
                            {
                            }

                            stream.Write(c);

                            x += 1;
                            UpdateProgress(x);
                        }
                        c = System.Convert.ToString(Program._frmMain.lvServices.Items.Count) + " service(s)";
                        stream.Write(c);
                        stream.Close();
                    }
                    else
                    {
                        // HTML
                        string title = System.Convert.ToString(Program._frmMain.lvServices.Items.Count) + " service(s)";
                        cHTML2 _html = new cHTML2(s, title, 25);

                        int x = 0;
                        foreach (cService cm in Program._frmMain.lvServices.GetAllItems())
                        {
                            try
                            {
                                // Try to access to the service (avoid to write lines if service
                                // is deleted)
                                string suseless = cm.Infos.LoadOrderGroup;

                                _html.AppendTitleLine(cm.Infos.Name);
                                string[] _lin = new string[2];
                                _lin[0] = "Name";
                                _lin[1] = cm.Infos.Name;
                                _html.AppendLine(_lin);
                                _lin[0] = "Common name";
                                _lin[1] = cm.Infos.DisplayName;
                                _html.AppendLine(_lin);
                                _lin[0] = "Path";
                                _lin[1] = cm.GetInformation("ImagePath");
                                _html.AppendLine(_lin);
                                _lin[0] = "ObjectName";
                                _lin[1] = cm.Infos.ObjectName;
                                _html.AppendLine(_lin);
                                _lin[0] = "State";
                                _lin[1] = cm.Infos.State.ToString();
                                _html.AppendLine(_lin);
                                _lin[0] = "Startup";
                                _lin[1] = cm.Infos.StartType.ToString();
                                _html.AppendLine(_lin);

                                x += 1;
                                UpdateProgress(x);
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        _html.ExportHTML();
                    }

                    ReportSaved("processes");
                }
            }
        }
        catch (Exception ex)
        {
            this.ReportFailed(ex);
        }
        this.cmdGO.Enabled = true;
    }
}
