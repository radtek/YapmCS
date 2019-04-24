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
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System;
using Microsoft.Samples;

public class cMonitor : IDisposable
{


    // ========================================
    // Constructor & destructor
    // ========================================
    public cMonitor(string category, string counter, string instance, string machine = null) : base()
    {
        timer = new System.Timers.Timer();
        timer.Stop();
        _enabled = false;
        _categoryName = category;
        _counterName = counter;
        _instanceName = instance;
        _machineName = machine;
        try
        {
            if (machine != null)
                _pc = new System.Diagnostics.PerformanceCounter(category, counter, instance, machine);
            else
                _pc = new System.Diagnostics.PerformanceCounter(category, counter, instance);
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to create performance counter");
        }
        _colInfos = new Collection();
        _monitorCreated = DateTime.Now;
    }

    // ========================================
    // Public declarations
    // ========================================
    public struct MonitorStructure
    {
        public object value;
        public int time;
    }


    // ========================================
    // Private attributes
    // ========================================
    private System.Timers.Timer _timer;

    private System.Timers.Timer timer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _timer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_timer != null)
            {
            }

            _timer = value;
            if (_timer != null)
            {
            }
        }
    }

    private System.Diagnostics.PerformanceCounter _pc;
    private int _Interval = 1000;
    private string _procName;
    private string _categoryName;
    private string _counterName;
    private string _instanceName;
    private Collection _colInfos;
    private bool _enabled = false;
    private DateTime _monitorCreated;
    private string _machineName;
    private DateTime _lastStarted;


    // ========================================
    // Getter & setter
    // ========================================
    public string MachineName
    {
        get
        {
            if (_machineName == null)
                return "localhost";
            else
                return _machineName;
        }
    }
    public string CategoryName
    {
        get
        {
            return _categoryName;
        }
    }
    public string CounterName
    {
        get
        {
            return _counterName;
        }
    }
    public MonitorStructure GetMonitorItem(int Index)
    {
        return (MonitorStructure)_colInfos[Index];
    }
    public MonitorStructure GetMonitorItem(object Index)
    {
        return (MonitorStructure)_colInfos[Index];
    }
    public MonitorStructure GetMonitorItem(string Key)
    {
        return (MonitorStructure)_colInfos[Key];
    }
    public DateTime MonitorCreationDate
    {
        get
        {
            return _monitorCreated;
        }
    }
    public DateTime LastStarted
    {
        get
        {
            return _lastStarted;
        }
    }
    public string Name
    {
        get
        {
            return _procName;
        }
    }
    public Collection GetMonitorItems()
    {
        return _colInfos;
    }
    public int Interval
    {
        get
        {
            return _Interval;
        }
        set
        {
            if (value > 0)
            {
                _Interval = value;
                timer.Interval = value;
            }
        }
    }
    public bool Enabled
    {
        get
        {
            return _enabled;
        }
        set
        {
            _enabled = value;
        }
    }
    public string InstanceName
    {
        get
        {
            return _instanceName;
        }
    }
    ~cMonitor()
    {
        _colInfos = null;
        if (timer != null)
        {
            this.StopMonitoring();
            timer.Dispose();
        }
        if (_pc != null)
            _pc.Dispose();
    }
    public void Dispose()
    {
        _colInfos = null;
        if (timer != null)
        {
            this.StopMonitoring();
            timer.Dispose();
        }
        if (_pc != null)
            _pc.Dispose();
        _pc = null;
    }


    // ========================================
    // Public functions
    // ========================================

    // Here we retrive desired informations
    public void RetrieveInformationsNow(string Key)
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
        Static locTime As Integer = 0

 */
        locTime += 1;
        MonitorStructure it = new MonitorStructure();
        {
            var withBlock = it;
            long tmp = DateTime.Now.Ticks - this.MonitorCreationDate.Ticks;
            withBlock.time = System.Convert.ToInt32(tmp / (double)10000);   // milliseconds from start
            try
            {
                withBlock.value = _pc.NextValue();
            }
            catch (Exception ex)
            {
                withBlock.value = null;
            }
        }
        try
        {
            _colInfos.Add(it, Key);
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }

    // Start monitoring
    public void StartMonitoring()
    {
        _enabled = true;
        timer.Start();
        _lastStarted = DateTime.Now;
    }

    // Stop monitoring
    public void StopMonitoring()
    {
        _enabled = false;
        timer.Stop();
    }



    // ========================================
    // Private functions
    // ========================================

    // Event (timer)
    private void TimerIntervalElapsed(System.Object sender, System.Timers.ElapsedEventArgs e)
    {
        RetrieveInformationsNow(System.Convert.ToString(DateTime.Now.Ticks));
    }
}

