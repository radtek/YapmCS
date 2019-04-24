using System.Diagnostics;
using System.Windows.Forms;
using Common;
using System;
using System.Runtime.InteropServices;

public partial class frmDepViewerMain
{
    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    private static int SetWindowTheme(IntPtr hWnd, string appName, string partList)
    {
    }

    private NativeDependenciesTree tree;

    public void OpenReferences(string asmFile)
    {
        this.Text = "Dependencies - " + asmFile;
        try
        {
            tree = new NativeDependenciesTree(asmFile);
            tvDepends.Nodes.Clear();
            tvDepends.Nodes.Add(this.CreateExpandableReferenceNode(tree.MainDll));

            lvAllDeps.BeginUpdate();
            lvAllDeps.Items.Clear();
            foreach (NativeDependenciesTree.NativeDependency dep in tree.GetAllDependencies())
            {
                if (dep.Resolved)
                {
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(dep.PE.FileName);
                    lvAllDeps.Items.Add(new ListViewItem(new string[] { System.IO.Path.GetFileName(dep.FileName), dep.PE.TimeStamp.ToString("dd/MM/yyyy HH:mm:ss"), dep.PE.NTHeader.SizeOfImage.ToString(), dep.PE.Machine.ToString(), dep.PE.NTHeader.Subsystem.ToString(), fvi.ProductName, fvi.CompanyName, fvi.FileVersion, fvi.ProductVersion, string.Format("{0}.{1}", dep.PE.OptionalHeader.MajorLinkerVersion, dep.PE.OptionalHeader.MinorLinkerVersion), dep.PE.FileName }, "dll"));
                }
                else
                    lvAllDeps.Items.Add(new ListViewItem(new string[] { System.IO.Path.GetFileName(dep.FileName) }, "unresolved"));
            }
            lvAllDeps.EndUpdate();

            // Select first node in tv
            this.tvDepends.SelectedNode = this.tvDepends.Nodes[0];

            NativeDependenciesTree.NativeDependency refNode = (NativeDependenciesTree.NativeDependency)this.tvDepends.SelectedNode.Tag;
            statusFile.Text = refNode.PE.FileName;
            if (refNode.Resolved)
                this.ShowAssemblyInfos(refNode);
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private TreeNode CreateAssemblyNode(NativeDependenciesTree.NativeDependency refNode)
    {
        TreeNode n = new TreeNode();
        if (!refNode.Resolved)
        {
            n.Text = System.IO.Path.GetFileName(refNode.FileName);
            n.ToolTipText = refNode.FileName;
            n.ImageKey = "unresolved";
            n.SelectedImageKey = "unresolved";
            n.StateImageKey = "unresolved";
        }
        else
        {
            n.Text = System.IO.Path.GetFileName(refNode.FileName);
            n.ToolTipText = refNode.PE.FileName;
            n.ImageKey = "dll";
            n.SelectedImageKey = "dll";
            n.StateImageKey = "dll";
        }

        n.Tag = refNode;

        return n;
    }
    private TreeNode CreateExpandableReferenceNode(NativeDependenciesTree.NativeDependency refNode)
    {
        TreeNode n = this.CreateAssemblyNode(refNode);
        if (refNode.Resolved)
        {
            TreeNode dummy = new TreeNode();
            dummy.Tag = "dummy";
            n.Nodes.Add(dummy);
        }
        return n;
    }

    private void FillAssemblyNode(TreeNode parent)
    {
        NativeDependenciesTree.NativeDependency refNode = (NativeDependenciesTree.NativeDependency)parent.Tag;

        foreach (NativeDependenciesTree.NativeDependency referencedDll in refNode.Dependencies)
            parent.Nodes.Add(this.CreateExpandableReferenceNode(referencedDll));
    }

    private void tvDepends_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        try
        {
            NativeDependenciesTree.NativeDependency refNode = (NativeDependenciesTree.NativeDependency)e.Node.Tag;
            statusFile.Text = refNode.PE.FileName;
            if (refNode.Resolved)
                this.ShowAssemblyInfos(refNode);
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void ShowAssemblyInfos(NativeDependenciesTree.NativeDependency dll)
    {
        lvExports.BeginUpdate();
        lvExports.Items.Clear();
        foreach (ExportEntry export in dll.PE.ExportDirectory.ExportEntries)
            lvExports.Items.Add(new ListViewItem(new string[] { export.Ordinal.ToString(), export.Hint.ToString(), export.Name, export.ExportRVA.ToString("X8") }, "function"));
        lvExports.EndUpdate();

        lvImports.BeginUpdate();
        lvImports.Items.Clear();
        foreach (DllImportEntry refDll in dll.PE.ImportDirectory.DllEntries)
        {
            foreach (ImportEntry import in refDll.Entries)
                lvImports.Items.Add(new ListViewItem(new string[] { import.Ordinal.ToString(), import.Hint.ToString(), refDll.DllName, import.Name, import.Address.ToString("X8") }, "function"));
        }
        lvImports.EndUpdate();
    }

    private void tvDepends_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        if (!(e.Node.FirstNode == null) && "dummy".Equals(e.Node.FirstNode.Tag))
        {
            e.Node.FirstNode.Remove();
            this.FillAssemblyNode(e.Node);
        }
    }

    private void frmDepViewerMain_Load(System.Object sender, System.EventArgs e)
    {
        Native.Functions.Misc.SetTheme(this.lvAllDeps.Handle);
        Native.Functions.Misc.SetTheme(this.lvExports.Handle);
        Native.Functions.Misc.SetTheme(this.lvImports.Handle);
        Misc.CloseWithEchapKey(ref this);
    }

    public void HideOpenMenu()
    {
        this.MenuItemOpen.Visible = false;
        this.MenuItemSeparatorAfterOpen.Visible = false;
    }

    private void MenuItem1_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            if (this.tvDepends.SelectedNode != null)
            {
                string _p = ((NativeDependenciesTree.NativeDependency)this.tvDepends.SelectedNode.Tag).PE.FileName;
                if (System.IO.File.Exists(_p))
                    cFile.ShowFileProperty(_p, this.Handle);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void MenuItem2_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            if (this.tvDepends.SelectedNode != null)
            {
                string _p = ((NativeDependenciesTree.NativeDependency)this.tvDepends.SelectedNode.Tag).PE.FileName;
                if (System.IO.File.Exists(_p))
                    cFile.OpenDirectory(_p);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void MenuItem3_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            foreach (ListViewItem it in this.lvAllDeps.SelectedItems)
            {
                if (System.IO.File.Exists(it.SubItems[10].Text))
                    cFile.ShowFileProperty(it.SubItems[10].Text, this.Handle);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void MenuItem4_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            foreach (ListViewItem it in this.lvAllDeps.SelectedItems)
            {
                if (System.IO.File.Exists(it.SubItems[10].Text))
                    cFile.OpenDirectory(it.SubItems[10].Text);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void tvDepends_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (this.tvDepends.SelectedNode != null)
            {
                NativeDependenciesTree.NativeDependency _tmp = (NativeDependenciesTree.NativeDependency)this.tvDepends.SelectedNode.Tag;
                if (_tmp.PE != null)
                {
                    string _p = ((NativeDependenciesTree.NativeDependency)this.tvDepends.SelectedNode.Tag).PE.FileName;
                    this.MenuItem1.Enabled = (System.IO.File.Exists(_p));
                    this.MenuItem2.Enabled = this.MenuItem1.Enabled;
                }
                else
                {
                    this.MenuItem1.Enabled = false;
                    this.MenuItem2.Enabled = false;
                }
            }
            else
            {
                this.MenuItem1.Enabled = false;
                this.MenuItem2.Enabled = false;
            }
            this.cMenu1.Show(this.tvDepends, e.Location);
        }
    }

    private void lvAllDeps_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            try
            {
                if (this.lvAllDeps.SelectedItems.Count > 0)
                {
                    this.MenuItemFileProp.Enabled = System.IO.File.Exists(this.lvAllDeps.SelectedItems[0].SubItems[10].Text);
                    this.MenuItemOpenDir.Enabled = this.MenuItem1.Enabled;
                }
                else
                {
                    this.MenuItemFileProp.Enabled = false;
                    this.MenuItemOpenDir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.MenuItemFileProp.Enabled = false;
                this.MenuItemOpenDir.Enabled = false;
            }
            this.cMenu2.Show(this.lvAllDeps, e.Location);
        }
    }

    private void MenuItem3_Click_1(System.Object sender, System.EventArgs e)
    {
        try
        {
            if (this.tvDepends.SelectedNode != null)
            {
                string _p = ((NativeDependenciesTree.NativeDependency)this.tvDepends.SelectedNode.Tag).PE.FileName;
                if (System.IO.File.Exists(_p))
                    Misc.DisplayDetailsFile(_p);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void MenuItem4_Click_1(System.Object sender, System.EventArgs e)
    {
        try
        {
            if (this.tvDepends.SelectedNode != null)
            {
                string _p = ((NativeDependenciesTree.NativeDependency)this.tvDepends.SelectedNode.Tag).PE.FileName;
                if (System.IO.File.Exists(_p))
                {
                    Application.DoEvents();
                    Misc.SearchInternet(cFile.GetFileName(_p), this.Handle);
                }
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void MenuItemFileDet_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            foreach (ListViewItem it in this.lvAllDeps.SelectedItems)
            {
                if (System.IO.File.Exists(it.SubItems[10].Text))
                    Misc.DisplayDetailsFile(it.SubItems[10].Text);
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void MenuItemInternetSearch_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            foreach (ListViewItem it in this.lvAllDeps.SelectedItems)
            {
                if (System.IO.File.Exists(it.SubItems[10].Text))
                {
                    Application.DoEvents();
                    Misc.SearchInternet(cFile.GetFileName(it.SubItems[10].Text), this.Handle);
                }
            }
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    private void MenuItemOpen_Click(System.Object sender, System.EventArgs e)
    {
        if (MenuItemOpen.Visible)
        {
            CDO.AddExtension = true;
            CDO.CheckFileExists = true;
            CDO.CheckPathExists = true;
            CDO.DereferenceLinks = true;
            CDO.Filter = "Assemblies (exe,dll)|*.exe;*.dll|All|*.*";
            CDO.RestoreDirectory = true;
            if (CDO.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                OpenReferences(CDO.FileName);
        }
    }

    private void MenuItemQuit_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void MenuItemAlwaysVisible_Click(System.Object sender, System.EventArgs e)
    {
        this.MenuItemAlwaysVisible.Checked = !(this.MenuItemAlwaysVisible.Checked);
        this.TopMost = this.MenuItemAlwaysVisible.Checked;
    }
}
