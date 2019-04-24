using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;
using Microsoft.Samples;

public partial class frmGlobalReport
{
    private void cmdCancel_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void cmdSave_Click(System.Object sender, System.EventArgs e)
    {
        Program._frmMain.saveDial.Filter = "Text file (*.txt)|*.txt";
        Program._frmMain.saveDial.Title = "Save report";
        if (Program._frmMain.saveDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            saveReport(Program._frmMain.saveDial.FileName);
    }

    // Change caption
    private void setCaption(string s)
    {
        this.lblState.Text = s;
        // Dim x As Integer = CInt((pgb.Width - Me.pgb.CreateGraphics.MeasureString(s, Me.Font).Width) / 2)
        // Dim y As Integer = CInt((pgb.Height - Me.pgb.CreateGraphics.MeasureString(s, Me.Font).Height) / 2)
        // Me.pgb.CreateGraphics.DrawString(s, Me.Font, Brushes.Black, x, y)
        Application.DoEvents();
    }

    // Save global report
    public void saveReport(string _fileToSave)
    {

        // Services
        // Handles
        // Windows
        // Threads
        // General
        // Modules
        // Memory regions

        System.IO.StreamWriter stream = new System.IO.StreamWriter(_fileToSave, false);
        int _test = Native.Api.Win32.GetElapsedTime();

        // The goal is to retrieve all informations before saving it
        Dictionary<string, cService> _dicoServices = new Dictionary<string, cService>();
        // Dim _dicoHandles As New Dictionary(Of String, cHandle)
        // Dim _dicoWindows As New Dictionary(Of String, cWindow)
        Dictionary<int, cProcess> _dicoProcesses = new Dictionary<int, cProcess>();

        // == Services
        // TODO_
        // If Me.chkServices.Checked Then
        // setCaption("Retrieving running services...")
        // Dim _buffServ As New Dictionary(Of String, cService.LightService)
        // Dim _buffServ2 As New Dictionary(Of String, cService.LightService)
        // Dim _keyServ() As String
        // ReDim _keyServ(0)
        // Dim _enumServ As New cServEnum
        // Dim _servNumber As Integer = _enumServ.EnumerateApi(_keyServ, _
        // _buffServ, _buffServ2)
        // For Each it As cService.LightService In _buffServ2.Values
        // _dicoServices.Add(it.name, New cLocalService(it, it.name, _enumServ.SCManagerHandle))
        // Next
        // End If


        // == Processes
        // If True Then'TODO_
        // setCaption("Retrieving opened processes...")
        // Dim _buffServ As New Dictionary(Of String, cProcess.LightProcess)
        // Dim _keyServ() As String
        // ReDim _keyServ(0)
        // Dim _servNumber As Integer = cLocalProcess.Enumerate(_keyServ, _buffServ)
        // For Each it As cProcess.LightProcess In _buffServ.Values
        // _dicoProcesses.Add(it.pid, New cLocalProcess(it))
        // Next
        // End If



        // ======== Every informations about processes

        // pid <-> (Xid <-> lightX)
        // Dim _dicoThreads As New Dictionary(Of String, Dictionary(Of String, cThread.LightThread))
        // Dim _dicoModules As New Dictionary(Of String, Dictionary(Of String, cModule.MODULEENTRY32))
        Dictionary<string, Dictionary<string, Native.Api.NativeStructs.MemoryBasicInformation>> _dicoMemRegions = new Dictionary<string, Dictionary<string, Native.Api.NativeStructs.MemoryBasicInformation>>();


        // == Threads
        // If Me.chkThreads.Checked Then
        // setCaption("Retrieving opened threads...")
        // For Each pid As Integer In _dicoProcesses.Keys
        // Dim _buffServ As New Dictionary(Of String, cThread.LightThread)
        // Dim _threadKey() As String
        // ReDim _threadKey(0)
        // cThread.Enumerate(pid, _threadKey, _buffServ)
        // _dicoThreads.Add(pid.ToString, _buffServ)
        // Next
        // End If


        // == Modules
        // If Me.chkModules.Checked Then
        // setCaption("Retrieving loaded modules...")
        // For Each pid As Integer In _dicoProcesses.Keys
        // Dim _buffServ As New Dictionary(Of String, cModule.MODULEENTRY32)
        // Dim _moduleKey() As String
        // ReDim _moduleKey(0)
        // cLocalModule.Enumerate(pid, _moduleKey, _buffServ)
        // _dicoModules.Add(pid.ToString, _buffServ)
        // Next
        // End If


        // == Memory regions
        // If Me.chkMemory.Checked Then
        // setCaption("Retrieving memory regions...")
        // For Each pid As Integer In _dicoProcesses.Keys
        // Dim _buffServ As New Dictionary(Of String, Native.Api.NativeStructs.MemoryBasicInformation)
        // Dim _memKey() As String
        // ReDim _memKey(0)
        // ProcessRW.Enumerate(pid, _memKey, _buffServ)
        // _dicoMemRegions.Add(pid.ToString, _buffServ)
        // Next
        // End If


        // == Write general informations to log
        setCaption("Writing header to report...");
        stream.WriteLine("Report generated by Yet Another (remote) Process Monitor");
        stream.WriteLine("File version : " + My.MyProject.Application.Info.Version.ToString());
        stream.WriteLine(DateTime.Now.ToLongDateString() + " -- " + DateTime.Now.ToLongTimeString());
        stream.WriteLine();
        stream.WriteLine();
        stream.WriteLine();


        // == Write informations about system


        // == Write services informations
        if (this.chkServices.Checked)
        {
            setCaption("Writing services list to report...");
            stream.WriteLine("================================");
            stream.WriteLine("==      Running services      ==");
            stream.WriteLine("================================");
            stream.WriteLine();
            stream.WriteLine(_dicoServices.Count.ToString() + " services running");
            stream.WriteLine();
            foreach (cService it in _dicoServices.Values)
            {
                stream.WriteLine("--------------------------------");
                stream.WriteLine("Service name : " + it.Infos.Name);
                stream.WriteLine("--------------------------------");
                foreach (string s in serviceInfos.GetAvailableProperties())
                    stream.WriteLine(s + " : " + it.GetInformation(s));
                stream.WriteLine();
            }
            stream.WriteLine();
            stream.WriteLine();
            stream.WriteLine();
        }


        // == Write informations about processes
        setCaption("Writing processes infos to report...");
        stream.WriteLine("================================");
        stream.WriteLine("==      Running processes     ==");
        stream.WriteLine("================================");
        stream.WriteLine();
        stream.WriteLine(_dicoProcesses.Count.ToString() + " processes running");
        stream.WriteLine();
        this.pgb.Maximum = _dicoProcesses.Count;
        // Dim x As Integer = 0


        // For Each it As cProcess In _dicoProcesses.Values
        // x += 1
        // Me.UpdateProgress(x)
        // stream.WriteLine()
        // stream.WriteLine("--------------------------------")
        // stream.WriteLine("Process name : " & it.Name)
        // stream.WriteLine("--------------------------------")
        // For Each s As String In cProcess.GetAvailableProperties
        // stream.WriteLine(s & " : " & it.GetInformation(s))
        // Next
        // stream.WriteLine()
        // stream.WriteLine()

        // If Me.chkThreads.Checked Then
        // If _dicoThreads.ContainsKey(it.Pid.ToString) Then
        // stream.WriteLine(_dicoThreads(it.Pid.ToString).Count & " threads running")
        // stream.WriteLine()
        // If Me.chkFull.Checked Then
        // For Each it2 As cThread.LightThread In _dicoThreads(it.Pid.ToString).Values
        // stream.WriteLine("---------------")
        // stream.WriteLine("Threads id : " & it2.t.Id.ToString)
        // stream.WriteLine("---------------")
        // Dim __t As cThread = New cThread(it2)
        // For Each s As String In cThread.GetAvailableProperties
        // stream.WriteLine(s & " : " & __t.GetInformation(s))
        // Next
        // Next
        // Else
        // For Each it2 As cThread.LightThread In _dicoThreads(it.Pid.ToString).Values
        // stream.WriteLine("Threads id : " & it2.t.Id.ToString)
        // Next
        // End If
        // stream.WriteLine()
        // End If
        // End If

        // If Me.chkModules.Checked Then
        // If _dicoModules.ContainsKey(it.Pid.ToString) Then
        // stream.WriteLine(_dicoModules(it.Pid.ToString).Count & " modules loaded")
        // stream.WriteLine()
        // If Me.chkFull.Checked Then
        // For Each it2 As cModule.MODULEENTRY32 In _dicoModules(it.Pid.ToString).Values
        // stream.WriteLine("---------------")
        // stream.WriteLine("Module name : " & it2.szModule)
        // stream.WriteLine("---------------")
        // Dim __t As cModule = New cLocalModule("no_need", it2)
        // For Each s As String In cModule.GetAvailableProperties
        // stream.WriteLine(s & " : " & __t.GetInformation(s))
        // Next
        // Next
        // Else
        // For Each it2 As cModule.MODULEENTRY32 In _dicoModules(it.Pid.ToString).Values
        // stream.WriteLine("Module : " & it2.szExePath)
        // Next
        // End If
        // stream.WriteLine()
        // End If
        // End If

        // If Me.chkMemory.Checked Then
        // If _dicoMemRegions.ContainsKey(it.Pid.ToString) Then
        // stream.WriteLine(_dicoMemRegions(it.Pid.ToString).Count & " memory regions")
        // stream.WriteLine()
        // If Me.chkFull.Checked Then
        // For Each it2 As Native.Api.NativeStructs.MemoryBasicInformations In _dicoMemRegions(it.Pid.ToString).Values
        // stream.WriteLine("---------------")
        // stream.WriteLine("Region address : 0x" & it2.BaseAddress.ToString("x"))
        // stream.WriteLine("---------------")
        // Dim __t As cMemRegion = New cMemRegion("no_need", it2, it.Pid)
        // For Each s As String In cMemRegion.GetAvailableProperties
        // stream.WriteLine(s & " : " & __t.GetInformation(s))
        // Next
        // Next
        // Else
        // For Each it2 As Native.Api.NativeStructs.MemoryBasicInformations In _dicoMemRegions(it.Pid.ToString).Values
        // stream.WriteLine("Address : 0x" & it2.BaseAddress.ToString("x") & " -- Size : " & GetFormatedSize(it2.RegionSize))
        // Next
        // End If
        // stream.WriteLine()
        // End If
        // End If

        // If Me.chkWindows.Checked Then
        // Dim _buffServ As New Dictionary(Of String, cWindow.LightWindow)
        // Dim _keyServ() As Integer
        // ReDim _keyServ(0)
        // Dim __pid(0) As Integer
        // __pid(0) = it.Pid
        // Dim _servNumber As Integer = cWindow.Enumerate(True, __pid, _keyServ, _buffServ)
        // _dicoWindows.Clear()
        // For Each i0t As cWindow.LightWindow In _buffServ.Values
        // _dicoWindows.Add(i0t.handle.ToString, New cWindow(i0t))
        // Next
        // stream.WriteLine(_dicoWindows.Count & " opened windows")
        // stream.WriteLine()
        // If Me.chkFull.Checked Then
        // For Each it2 As cWindow In _dicoWindows.Values
        // If Me.chkAllWindows.Checked OrElse Len(it2.Caption) > 0 Then
        // stream.WriteLine("---------------")
        // stream.WriteLine("Window handle : " & it2.Handle.ToString)
        // stream.WriteLine("---------------")
        // For Each s As String In cWindow.GetAvailableProperties
        // stream.WriteLine(s & " : " & it2.GetInformation(s))
        // Next
        // End If
        // Next
        // Else
        // For Each it2 As cWindow In _dicoWindows.Values
        // If Me.chkAllWindows.Checked OrElse Len(it2.Caption) > 0 Then
        // stream.WriteLine("Handle : " & it2.Handle.ToString & " -- Visible : " & it2.Visible.ToString & " -- Task : " & it2.IsTask.ToString & " -- Caption : " & it2.Caption)
        // End If
        // Next
        // End If
        // stream.WriteLine()
        // End If

        // If Me.chkHandles.Checked Then
        // Dim _buffServ As New Dictionary(Of String, cHandle.LightHandle)
        // Dim _keyServ() As String
        // ReDim _keyServ(0)
        // Dim __pid(0) As Integer
        // __pid(0) = it.Pid
        // Dim _servNumber As Integer = cHandle.Enumerate(__pid, True, _keyServ, _buffServ)
        // _dicoHandles.Clear()
        // For Each i0t As cHandle.LightHandle In _buffServ.Values
        // Dim _key As String = cHandle.GetKeyFromLight(i0t)
        // _dicoHandles.Add(_key, New cHandle(_key, i0t))
        // Next
        // 'If _dicoHandles.ContainsKey(it.Pid.ToString) Then
        // stream.WriteLine(_dicoHandles.Count & " handles opened")
        // stream.WriteLine()
        // If Me.chkFull.Checked Then
        // For Each it2 As cHandle In _dicoHandles.Values
        // If Me.chkAllHandles.Checked OrElse Len(it2.Name) > 0 Then
        // stream.WriteLine("---------------")
        // stream.WriteLine("Handle : " & it2.Handle.ToString)
        // stream.WriteLine("---------------")
        // For Each s As String In cHandle.GetAvailableProperties
        // stream.WriteLine(s & " : " & it2.GetInformation(s))
        // Next
        // End If
        // Next
        // Else
        // For Each it2 As cHandle In _dicoHandles.Values
        // If Me.chkAllHandles.Checked OrElse Len(it2.Name) > 0 Then
        // stream.WriteLine("Handle : " & it2.Handle.ToString & " -- Type : " & it2.Type & " -- Name : " & it2.Name)
        // End If
        // Next
        // End If
        // stream.WriteLine()
        // End If
        // ' End If
        // Next'TODO_
        stream.WriteLine();


        stream.Close();
        _test = Native.Api.Win32.GetElapsedTime() - _test;
        setCaption("Done in " + _test.ToString() + " ms");

        Misc.ShowMsg("System report", "Saved report successfully.", null, MessageBoxButtons.OK, TaskDialogIcon.Information);
    }

    private void frmGlobalReport_Load(object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Misc.SetToolTip(this.chkAllHandles, "Get all handles (including unnamed handles)");
        Misc.SetToolTip(this.chkAllWindows, "Get all windows (including unnamed windows)");
        Misc.SetToolTip(this.chkFull, "Write a complet report, with all informations availables. You should NOT use this option because report file can be up to 100MB");
        Misc.SetToolTip(this.chkHandles, "Write handles infos");
        Misc.SetToolTip(this.chkMemory, "Write memory regions infos");
        Misc.SetToolTip(this.chkModules, "Write modules infos");
        Misc.SetToolTip(this.chkServices, "Write services infos");
        Misc.SetToolTip(this.chkThreads, "Write threads infos");
        Misc.SetToolTip(this.chkWindows, "Write windows infos");
        Misc.SetToolTip(this.cmdCancel, "Cancel");
        Misc.SetToolTip(this.cmdSave, "Save report as a text file");
    }
}
