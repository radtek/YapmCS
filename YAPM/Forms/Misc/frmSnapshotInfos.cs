using System.Windows.Forms;
using Common;
using System;

public partial class frmSnapshotInfos
{
    private void frmFileRelease_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdOK, "OK");
        Misc.SetToolTip(this.cmdBrowseSSFile, "Select the System Snapshot File");
        Misc.SetToolTip(this.cmdGo, "Explore file");
        Native.Functions.Misc.SetTheme(this.tv.Handle);
    }

    private void cmdOK_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void cmdGo_Click(System.Object sender, System.EventArgs e)
    {
        if (System.IO.File.Exists(this.txtSSFile.Text))
        {
            this.Text = "System Snapshot File information - Exploring file...";
            try
            {
                cSnapshot snap = new cSnapshot(ref this.txtSSFile.Text);
                this.Text = "System Snapshot File information - Building tree...";
                this.BuildTree(snap);
                this.Text = "System Snapshot File information";
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Could not explore file !");
                this.Text = "System Snapshot File information - Failed to explore file";
            }
        }
    }

    private void cmdBrowseSSFile_Click(System.Object sender, System.EventArgs e)
    {
        DialogResult ret = this.openFile.ShowDialog();
        if (ret == System.Windows.Forms.DialogResult.OK)
            this.txtSSFile.Text = this.openFile.FileName;
    }

    // Build the tree with ssfile info
    private void BuildTree(cSnapshot snap)
    {
        this.tv.Nodes.Clear();
        this.tv.BeginUpdate();

        // Root nodes
        TreeNode rootRoot = new TreeNode("Snapshot");
        TreeNode rootInfo = new TreeNode("Information about the snapshot");
        TreeNode rootData = new TreeNode("Embedded data");
        rootRoot.Nodes.Add(rootInfo);
        rootRoot.Nodes.Add(rootData);
        this.tv.Nodes.Add(rootRoot);

        // Informations about the snapshot
        rootInfo.Nodes.Add("File type version : " + snap.FileVersion);
        rootInfo.Nodes.Add("Date : " + snap.Date.ToLongDateString() + "-" + snap.Date.ToLongTimeString());
        if (snap.SystemInformation != null)
        {
            rootInfo.Nodes.Add("ComputerName : " + snap.SystemInformation.ComputerName);
            rootInfo.Nodes.Add("UserName : " + snap.SystemInformation.UserName);
            rootInfo.Nodes.Add("Culture : " + snap.SystemInformation.Culture.ToString());
            rootInfo.Nodes.Add("IntPtrSize : " + snap.SystemInformation.IntPtrSize);
            rootInfo.Nodes.Add("OSFullName : " + snap.SystemInformation.OSFullName);
            rootInfo.Nodes.Add("OSPlatform : " + snap.SystemInformation.OSPlatform);
            rootInfo.Nodes.Add("OSVersion : " + snap.SystemInformation.OSVersion);
            rootInfo.Nodes.Add("AvailablePhysicalMemory : " + Misc.GetFormatedSize(snap.SystemInformation.AvailablePhysicalMemory));
            rootInfo.Nodes.Add("AvailableVirtualMemory : " + Misc.GetFormatedSize(snap.SystemInformation.AvailableVirtualMemory));
            rootInfo.Nodes.Add("TotalPhysicalMemory : " + Misc.GetFormatedSize(snap.SystemInformation.TotalPhysicalMemory));
            rootInfo.Nodes.Add("TotalVirtualMemory : " + Misc.GetFormatedSize(snap.SystemInformation.TotalVirtualMemory));
        }

        // Processes
        if (snap.Processes != null)
        {
            TreeNode rootProcess = rootData.Nodes.Add("Processes");
            foreach (System.Collections.Generic.KeyValuePair<string, processInfos> pair in snap.Processes)
            {
                TreeNode n = new TreeNode(pair.Key + " - " + pair.Value.Name);

                // Env var
                if (snap.EnvironnementVariablesByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nEnv = new TreeNode("Environment variables");
                    n.Nodes.Add(nEnv);
                    foreach (System.Collections.Generic.KeyValuePair<string, envVariableInfos> pair2 in snap.EnvironnementVariablesByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tEnv = nEnv.Nodes.Add(pair2.Value.Variable);
                        tEnv.Nodes.Add(pair2.Value.Value);
                    }
                }

                // Handles
                if (snap.HandlesByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nHandles = new TreeNode("Handles");
                    n.Nodes.Add(nHandles);
                    foreach (System.Collections.Generic.KeyValuePair<string, handleInfos> pair2 in snap.HandlesByProcessId(pair.Value.ProcessId))
                    {
                        string sss = "0x" + pair2.Value.Handle.ToString("x");
                        if (pair2.Value.Name != null && pair2.Value.Name.Length > 0)
                            sss += " (" + pair2.Value.Name + ")";
                        TreeNode tHandle = nHandles.Nodes.Add(sss);
                        foreach (string info2 in handleInfos.GetAvailableProperties())
                            tHandle.Nodes.Add(info2 + " : " + new cHandle(pair2.Value).GetInformation(info2));
                    }
                }

                // Heaps
                if (snap.HeapsByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nHeaps = new TreeNode("Heaps");
                    n.Nodes.Add(nHeaps);
                    foreach (System.Collections.Generic.KeyValuePair<string, heapInfos> pair2 in snap.HeapsByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tHeap = nHeaps.Nodes.Add("0x" + pair2.Value.BaseAddress.ToString("x"));
                        foreach (string info2 in heapInfos.GetAvailableProperties())
                            tHeap.Nodes.Add(info2 + " : " + new cHeap(pair2.Value).GetInformation(info2));
                    }
                }

                // Mem region
                if (snap.MemoryRegionsByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nMemRegions = new TreeNode("Memory regions");
                    n.Nodes.Add(nMemRegions);
                    foreach (System.Collections.Generic.KeyValuePair<string, memRegionInfos> pair2 in snap.MemoryRegionsByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tMem = nMemRegions.Nodes.Add("0x" + pair2.Value.BaseAddress.ToString("x"));
                        foreach (string info2 in memRegionInfos.GetAvailableProperties())
                            tMem.Nodes.Add(info2 + " : " + new cMemRegion(pair2.Value).GetInformation(info2));
                    }
                }

                // Modules
                if (snap.ModulesByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nModules = new TreeNode("Modules");
                    n.Nodes.Add(nModules);
                    foreach (System.Collections.Generic.KeyValuePair<string, moduleInfos> pair2 in snap.ModulesByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tModule = nModules.Nodes.Add(pair2.Value.Name);
                        foreach (string info2 in moduleInfos.GetAvailableProperties())
                            tModule.Nodes.Add(info2 + " : " + new cModule(pair2.Value).GetInformation(info2));
                    }
                }

                // Network connections
                if (snap.NetworkConnectionsByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nConn = new TreeNode("Network connections");
                    n.Nodes.Add(nConn);
                    int i2 = 0;
                    foreach (System.Collections.Generic.KeyValuePair<string, networkInfos> pair2 in snap.NetworkConnectionsByProcessId(pair.Value.ProcessId))
                    {
                        i2 += 1;
                        TreeNode tNet = nConn.Nodes.Add("Connection " + i2.ToString());
                        foreach (string info2 in networkInfos.GetAvailableProperties())
                            tNet.Nodes.Add(info2 + " : " + new cNetwork(pair2.Value).GetInformation(info2));
                    }
                }

                // Privileges
                if (snap.PrivilegesByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nPriv = new TreeNode("Privileges");
                    n.Nodes.Add(nPriv);
                    foreach (System.Collections.Generic.KeyValuePair<string, privilegeInfos> pair2 in snap.PrivilegesByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tPri = nPriv.Nodes.Add(pair2.Value.Name);
                        foreach (string info2 in privilegeInfos.GetAvailableProperties())
                            tPri.Nodes.Add(info2 + " : " + new cPrivilege(pair2.Value).GetInformation(info2));
                    }
                }

                // Services
                if (snap.ServicesByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nServ = new TreeNode("Services");
                    n.Nodes.Add(nServ);
                    foreach (System.Collections.Generic.KeyValuePair<string, serviceInfos> pair2 in snap.ServicesByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tServ = nServ.Nodes.Add(pair2.Value.Name);
                        foreach (string info2 in serviceInfos.GetAvailableProperties())
                            tServ.Nodes.Add(info2 + " : " + new cService(pair2.Value).GetInformation(info2));
                    }
                }

                // Threads
                if (snap.ThreadsByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nThreads = new TreeNode("Threads");
                    n.Nodes.Add(nThreads);
                    foreach (System.Collections.Generic.KeyValuePair<string, threadInfos> pair2 in snap.ThreadsByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tThread = nThreads.Nodes.Add(pair2.Value.Id.ToString());
                        foreach (string info2 in threadInfos.GetAvailableProperties())
                            tThread.Nodes.Add(info2 + " : " + new cThread(pair2.Value).GetInformation(info2));
                    }
                }

                // Windows
                if (snap.WindowsByProcessId(pair.Value.ProcessId).Count > 0)
                {
                    TreeNode nWindows = new TreeNode("Windows");
                    n.Nodes.Add(nWindows);
                    foreach (System.Collections.Generic.KeyValuePair<string, windowInfos> pair2 in snap.WindowsByProcessId(pair.Value.ProcessId))
                    {
                        TreeNode tW = nWindows.Nodes.Add(pair2.Value.Handle.ToString());
                        foreach (string info2 in windowInfos.GetAvailableProperties())
                            tW.Nodes.Add(info2 + " : " + new cWindow(pair2.Value).GetInformation(info2));
                    }
                }

                // Infos about the process
                foreach (string info in processInfos.GetAvailableProperties())
                    n.Nodes.Add(info + " : " + new cProcess(pair.Value).GetInformation(info));
                rootProcess.Nodes.Add(n);
            }
        }

        // Services
        if (snap.Services != null)
        {
            TreeNode rootService = rootData.Nodes.Add("Services");
            foreach (System.Collections.Generic.KeyValuePair<string, serviceInfos> pair in snap.Services)
            {
                TreeNode n = new TreeNode(pair.Key);
                rootService.Nodes.Add(n);
                foreach (string info in serviceInfos.GetAvailableProperties())
                    n.Nodes.Add(info + " : " + new cService(pair.Value).GetInformation(info));
            }
        }

        // Network connections
        if (snap.NetworkConnections != null)
        {
            TreeNode rootNetwork = rootData.Nodes.Add("Network connections");
            int i = 0;
            foreach (System.Collections.Generic.KeyValuePair<string, networkInfos> pair in snap.NetworkConnections)
            {
                i += 1;
                TreeNode n = new TreeNode("Item " + i.ToString());
                rootNetwork.Nodes.Add(n);
                foreach (string info in networkInfos.GetAvailableProperties())
                    n.Nodes.Add(info + " : " + new cNetwork(pair.Value).GetInformation(info));
            }
        }

        // Tasks
        if (snap.Tasks != null)
        {
            TreeNode rootTask = rootData.Nodes.Add("Tasks");
            foreach (System.Collections.Generic.KeyValuePair<string, windowInfos> pair in snap.Tasks)
            {
                TreeNode n = new TreeNode("Handle : " + pair.Value.Handle.ToString());
                rootTask.Nodes.Add(n);
                foreach (string info in windowInfos.GetAvailableProperties())
                    n.Nodes.Add(info + " : " + new cTask(pair.Value).GetInformation(info));
            }
        }

        // Jobs
        if (snap.Jobs != null)
        {
            TreeNode rootJob = rootData.Nodes.Add("Jobs");
            foreach (System.Collections.Generic.KeyValuePair<string, jobInfos> pair in snap.Jobs)
            {
                TreeNode n = new TreeNode(pair.Key);
                rootJob.Nodes.Add(n);
                foreach (string info in jobInfos.GetAvailableProperties())
                    n.Nodes.Add(info + " : " + new cJob(pair.Value).GetInformation(info));
                TreeNode nLimits = new TreeNode("Limits");
                n.Nodes.Add(nLimits);
                foreach (System.Collections.Generic.KeyValuePair<string, jobLimitInfos> pair2 in snap.JobLimitsByJobName(pair.Key))
                {
                    TreeNode tLimit = nLimits.Nodes.Add(pair2.Value.Name);
                    foreach (string info2 in jobLimitInfos.GetAvailableProperties())
                        tLimit.Nodes.Add(info2 + " : " + new cJobLimit(pair2.Value).GetInformation(info2));
                }
            }
        }


        this.tv.EndUpdate();
    }
}
