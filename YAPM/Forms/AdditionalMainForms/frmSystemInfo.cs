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
using System.Windows.Forms;
using Common;
using System;

public partial class frmSystemInfo
{
    private int _processors = 1;

    private void timerRefresh_Tick(System.Object sender, System.EventArgs e)
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

        ' Get some date and date diff
        Static oldDate As Date = Date.Now

 */
        DateTime newDate = DateTime.Now;
        DateTime diff = new DateTime(newDate.Ticks - oldDate.Ticks);
        oldDate = newDate;

        {
            var withBlock = Program.SystemInfo;

            // Highest values are Decimals

            Native.Api.NativeStructs.SystemBasicInformation bi = withBlock.BasicInformations;
            Native.Api.NativeStructs.SystemCacheInformation ci = withBlock.CacheInformations;
            Native.Api.NativeStructs.SystemPerformanceInformation pi = withBlock.PerformanceInformations;
            Native.Api.NativeStructs.SystemProcessorPerformanceInformation[] ppi = withBlock.ProcessorPerformanceInformations;
            int _pagesize = bi.PageSize;
            _processors = bi.NumberOfProcessors;

            // Cache
            this.lblCacheCurrent.Text = Misc.GetFormatedSize(ci.SystemCacheWsSize);
            this.lblCacheErrors.Text = System.Convert.ToString(ci.SystemCacheWsFaults);
            this.lblCacheMaximum.Text = Misc.GetFormatedSize(decimal.Multiply(ci.SystemCacheWsMaximum.ToInt64(), _pagesize));
            this.lblCacheMinimum.Text = Misc.GetFormatedSize(ci.SystemCacheWsMinimum.ToInt64() * _pagesize);
            this.lblCachePeak.Text = Misc.GetFormatedSize(ci.SystemCacheWsPeakSize);

            // Total
            this.lblHandles.Text = System.Convert.ToString(withBlock.HandleCount);
            this.lblProcesses.Text = System.Convert.ToString(withBlock.ProcessCount);
            this.lblThreads.Text = System.Convert.ToString(withBlock.ThreadCount);

            // Commit charge
            this.lblCCC.Text = Misc.GetFormatedSize(pi.CommittedPages * _pagesize);
            this.lblCCP.Text = Misc.GetFormatedSize(decimal.Multiply(pi.PeakCommitment, _pagesize));
            this.lblCCL.Text = Misc.GetFormatedSize(decimal.Multiply(pi.CommitLimit, _pagesize));

            // Physical memory
            this.lblPMF.Text = Misc.GetFormatedSize(decimal.Multiply(pi.AvailablePages, _pagesize));
            this.lblPMT.Text = Misc.GetFormatedSize(decimal.Multiply(bi.NumberOfPhysicalPages, _pagesize));
            this.lblPMU.Text = Misc.GetFormatedSize(decimal.Multiply(decimal.Subtract(bi.NumberOfPhysicalPages, pi.AvailablePages), _pagesize));

            // I/O
            this.lblIOotherBytes.Text = Misc.GetFormatedSize(pi.IoOtherTransferCount);
            this.lblIOothers.Text = System.Convert.ToString(pi.IoOtherOperationCount);
            this.lblIOreadBytes.Text = Misc.GetFormatedSize(pi.IoReadTransferCount);
            this.lblIOreads.Text = System.Convert.ToString(pi.IoReadOperationCount);
            this.lblIOwriteBytes.Text = Misc.GetFormatedSize(pi.IoWriteTransferCount);
            this.lblIOwrites.Text = System.Convert.ToString(pi.IoWriteOperationCount);

            // Page faults
            this.lblPFcache.Text = System.Convert.ToString(ci.SystemCacheWsFaults);
            this.lblPFcacheTransition.Text = System.Convert.ToString(pi.CacheTransitionFaults);
            this.lblPFcopyOnWrite.Text = System.Convert.ToString(pi.CopyOnWriteFaults);
            this.lblPFdemandZero.Text = System.Convert.ToString(pi.DemandZeroFaults);
            this.lblPFtotal.Text = System.Convert.ToString(pi.PageFaults);
            this.lblPFtransition.Text = System.Convert.ToString(pi.TransitionFaults);

            // CPU
            this.lblCPUcontextSwitches.Text = System.Convert.ToString(pi.ContextSwitches);
            long zres0 = 0;
            long zres1 = 0;
            long zres2 = 0;
            long zres3 = 0;
            long zres4 = 0;
            long zres5 = 0;
            var loopTo = ppi.Length - 1;
            for (int x = 0; x <= loopTo; x++)
            {
                zres0 += ppi[x].InterruptCount;
                zres1 += System.Convert.ToInt64(ppi[x].IdleTime / (double)_processors);
                zres2 += System.Convert.ToInt64(ppi[x].InterruptTime / (double)_processors);
                zres3 += System.Convert.ToInt64(ppi[x].UserTime / (double)_processors);
                zres5 += System.Convert.ToInt64(ppi[x].DpcTime / (double)_processors);
                zres4 += System.Convert.ToInt64(ppi[x].KernelTime / (double)_processors);
            }
            zres4 = zres4 - zres5 - zres1 - zres2;
            this.lblCPUinterrupts.Text = System.Convert.ToString(zres0);
            this.lblCPUprocessors.Text = System.Convert.ToString(_processors);
            this.lblCPUsystemCalls.Text = System.Convert.ToString(pi.SystemCalls);
            double zTotal = zres4 + zres3 + zres1;

            DateTime ts = new DateTime(zres1);
            this.lblCPUidleTime.Text = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond) + " (" + Math.Round(zres1 / zTotal * 100, 3).ToString() + " %)";
            ts = new DateTime(zres2);
            this.lblCPUinterruptTime.Text = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond) + " (" + Math.Round(zres2 / zTotal * 100, 3).ToString() + " %)";
            ts = new DateTime(zres3);
            this.lblCPUuserTime.Text = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond) + " (" + Math.Round(zres3 / zTotal * 100, 3).ToString() + " %)";
            ts = new DateTime(zres4);
            this.lblCPUkernelTime.Text = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond) + " (" + Math.Round(zres4 / zTotal * 100, 3).ToString() + " %)";
            ts = new DateTime(zres5);
            this.lblCPUdpcTime.Text = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond) + " (" + Math.Round(zres5 / zTotal * 100, 3).ToString() + " %)";
            ts = new DateTime(zres2 + zres3 + zres4 + zres5);
            this.lblCPUTotalTime.Text = string.Format("{0:00}", ts.Hour) + ":" + string.Format("{0:00}", ts.Minute) + ":" + string.Format("{0:00}", ts.Second) + ":" + string.Format("{000}", ts.Millisecond) + " (100 %)";


            // Kernel pools
            this.lblKnpa.Text = System.Convert.ToString(pi.NonPagedPoolAllocs);
            this.lblKnpf.Text = System.Convert.ToString(pi.NonPagedPoolFrees);
            this.lblKnpu.Text = Misc.GetFormatedSize(decimal.Multiply(pi.NonPagedPoolUsage, _pagesize));
            this.lblKpf.Text = System.Convert.ToString(pi.PagedPoolFrees);
            this.lblKpp.Text = Misc.GetFormatedSize(decimal.Multiply(pi.PagedPoolPages, _pagesize));
            this.lblKpa.Text = System.Convert.ToString(pi.PagedPoolAllocs);


            // ======== Graphics
            // g1 (CPU)
            showCpuUsage(zres3, zres4, ref ppi, diff);


            // g2 (physical memory)
            double ggg2 = 100 * (bi.NumberOfPhysicalPages - pi.AvailablePages) / (double)bi.NumberOfPhysicalPages;
            this.g2.AddValue(ggg2);
            this.g2.TopText = "Phys. memory : " + Misc.GetFormatedSize(decimal.Multiply(bi.NumberOfPhysicalPages - pi.AvailablePages, _pagesize));
            this.g2.Refresh();
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


            ' g3 (I/O read+other)
            Static oldIOr As Long = 0

 */
            long newIOr = pi.IoReadTransferCount + pi.IoOtherTransferCount;
            long diffIOr = newIOr - oldIOr;
            oldIOr = newIOr;

            double v3;
            if (diff.Ticks > 0)
                v3 = diffIOr / (double)diff.Ticks;
            else
                v3 = 0;

            this.g3.AddValue(v3 * 100);
            this.g3.TopText = "R+O : " + Misc.GetFormatedSizePerSecond(diffIOr);
            this.g3.Refresh();
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


            ' g4 (I/O write)
            Static oldIOw As Long = 0

 */
            long newIOw = pi.IoWriteTransferCount;
            long diffIOw = newIOw - oldIOw;
            oldIOw = newIOw;

            double v4;
            if (diff.Ticks > 0)
                v4 = diffIOw / (double)diff.Ticks;
            else
                v4 = 0;

            this.g4.AddValue(v4 * 100);
            this.g4.TopText = "W : " + Misc.GetFormatedSizePerSecond(diffIOw);
            this.g4.Refresh();
        }
    }

    private void frmSystemInfo_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        // Save position & size
        Pref.SaveFormPositionAndSize(this, "PSfrmSystemInfo");
    }

    private void frmSystemInfo_Load(System.Object sender, System.EventArgs e)
    {
        Misc.SetToolTip(this.chkOneGraphPerCpu, "Display one graph per CPU or one graph for all CPUs");
        Misc.SetToolTip(this.chkTopMost, "Display window always on top");
        Misc.CloseWithEchapKey(ref this);

        // Init position & size
        Pref.LoadFormPositionAndSize(this, "PSfrmSystemInfo");

        this.timerRefresh.Interval = My.MySettingsProperty.Settings.SystemInterval;
        timerRefresh_Tick(null, null);
        this.chkOneGraphPerCpu.Enabled = (Program.SystemInfo.ProcessorCount > 1);

        this.chkTopMost.Checked = My.MySettingsProperty.Settings.SystemInfoTopMost;
        this.chkOneGraphPerCpu.Checked = !(My.MySettingsProperty.Settings.SystemInfoOneGraph);

        chkOneGraphPerCpu_CheckedChanged(null, null); // Add graphs
    }

    private void frmSystemInfo_Resize(object sender, System.EventArgs e)
    {
        this.g2.Refresh();
        this.g3.Refresh();
        this.g4.Refresh();
    }

    private void chkOneGraphPerCpu_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (My.MySettingsProperty.Settings.SystemInfoOneGraph != !(this.chkOneGraphPerCpu.Checked))
        {
            My.MySettingsProperty.Settings.SystemInfoOneGraph = !(this.chkOneGraphPerCpu.Checked);
            try
            {
                My.MySettingsProperty.Settings.Save();
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        // Delete graphs
        this.SplitContainer1.Panel1.Controls.Clear();

        // Add graphs
        if (chkOneGraphPerCpu.Checked == false)
        {
            // One graph
            Graph2 _g = new Graph2();
            _g.Dock = DockStyle.Fill;
            _g.Visible = true;
            _g.ColorGrid = Color.DarkGreen;
            _g.BackColor = Color.Black;
            _g.Name = "_graphCpuAll";
            _g.EnableGraph = true;
            _g.Fixedheight = true;
            _g.ShowSecondGraph = false;
            _g.Color = Color.LimeGreen;
            _g.Color2 = Color.Green;
            this.SplitContainer1.Panel1.Controls.Add(_g);
            _g.Refresh();
        }
        else
        {
            var loopTo = _processors - 1;
            // One graph per CPU
            for (int x = 0; x <= loopTo; x++)
            {
                Graph2 _g = new Graph2();
                _g.Dock = DockStyle.Left;
                _g.Visible = true;
                _g.ColorGrid = Color.DarkGreen;
                _g.BackColor = Color.Black;
                _g.Name = "_graph" + x.ToString();
                _g.Tag = x;
                _g.EnableGraph = true;
                _g.Fixedheight = true;
                _g.ShowSecondGraph = false;
                _g.Color = Color.LimeGreen;
                _g.Color2 = Color.Green;
                this.SplitContainer1.Panel1.Controls.Add(_g);
                if (x < _processors - 1)
                {
                    PictureBox _p = new PictureBox();
                    _p.BackColor = Color.Transparent;
                    _p.Width = 2;
                    _p.Dock = DockStyle.Left;
                    _p.Name = "_pct" + x.ToString();
                    this.SplitContainer1.Panel1.Controls.Add(_p);
                }
                _g.Refresh();
            }
            SplitContainer2_Resize(null, null);
        }
    }

    private void SplitContainer2_Resize(System.Object sender, System.EventArgs e)
    {
        // Recalculate width if one graph per CPU
        if (this.chkOneGraphPerCpu.Checked)
        {
            foreach (Control ct in this.SplitContainer1.Panel1.Controls)
            {
                if (ct is Graph2)
                {
                    ct.Width = System.Convert.ToInt32((this.SplitContainer1.Panel1.Width - 2 * (_processors - 1)) / (double)_processors);
                    ct.Refresh();
                }
            }
        }
    }

    private void showCpuUsage(long zres3, long zres4, ref Native.Api.NativeStructs.SystemProcessorPerformanceInformation[] ppi, DateTime diff)
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

        Static oldProcTime As Long = 0

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
        Static _old() As Long = Nothing

 */
        if (this.SplitContainer1.Panel1.Controls.Count == 0)
            // No CPU graph have been added
            // So we exit for now
            return;

        if (chkOneGraphPerCpu.Checked == false)
        {
            // One graph for all CPUs
            _old = null;
            long newProcTime = zres3 + zres4;
            long diffProcTime = newProcTime - oldProcTime;

            double v1;
            if (diff.Ticks > 0 && oldProcTime > 0)
                v1 = diffProcTime / (double)diff.Ticks / _processors;
            else
                v1 = 0;
            oldProcTime = newProcTime;

            Graph2 _g1 = (Graph2)this.SplitContainer1.Panel1.Controls[0];

            this.lblCPUUsage.Text = Misc.GetFormatedPercentage(v1, 3) + " %";
            _g1.AddValue(v1 * 100);
            _g1.TopText = "Cpu : " + Misc.GetFormatedPercentage(v1, 3, true) + " %";
            _g1.Refresh();
        }
        else
        {
            // One graph per CPU
            oldProcTime = 0;
            if (_old == null)
                _old = new long[_processors - 1 + 1];

            long[] _new;
            _new = new long[_processors - 1 + 1];
            var loopTo = _processors - 1;
            for (int x = 0; x <= loopTo; x++)
                _new[x] = ppi[x].UserTime + ppi[x].KernelTime - ppi[x].IdleTime - ppi[x].InterruptTime - ppi[x].DpcTime;

            long[] _diff;
            _diff = new long[_processors - 1 + 1];
            if (diff.Ticks > 0 && _old[0] > 0)
            {
                var loopTo1 = _processors - 1;
                for (int x = 0; x <= loopTo1; x++)
                    _diff[x] = _new[x] - _old[x];
            }
            else
            {
                var loopTo2 = _processors - 1;
                for (int x = 0; x <= loopTo2; x++)
                    _diff[x] = 0;
            }
            _old = _new;

            // Refresh graphs
            double _totalCpuDiff = 0;
            foreach (Control ct in this.SplitContainer1.Panel1.Controls)
            {
                if (ct is Graph2)
                {
                    Graph2 _g1 = (Graph2)ct;
                    int _i = System.Convert.ToInt32(_g1.Tag);
                    double z = _diff[_i] / (double)diff.Ticks / _processors;
                    _g1.AddValue(100 * z);
                    _totalCpuDiff += z;
                    _g1.TopText = "Cpu " + _i.ToString() + " : " + Misc.GetFormatedPercentage(z, 3, true) + " %";
                    _g1.Refresh();
                }
            }

            this.lblCPUUsage.Text = Misc.GetFormatedPercentage(_totalCpuDiff, 3) + " %";
        }
    }

    private void chkTopMost_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (this.chkTopMost.Checked != My.MySettingsProperty.Settings.SystemInfoTopMost)
        {
            My.MySettingsProperty.Settings.SystemInfoTopMost = this.chkTopMost.Checked;
            try
            {
                My.MySettingsProperty.Settings.Save();
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }
        this.TopMost = this.chkTopMost.Checked;
    }
}
