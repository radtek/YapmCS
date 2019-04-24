using System;
using System.Runtime.InteropServices;
using Native.Api;

public class cSystemInfo
{


    // ========================================
    // Private
    // ========================================
    private int _handles;
    private int _processes;
    private int _threads;
    private int _processors;
    private int _physicalPagesCount;
    private int _timerResolution;
    private IntPtr _maxCache;
    private IntPtr _currentCache;
    private IntPtr _minCache;
    private IntPtr _peakCache;
    private int _cacheErrors;
    private NativeStructs.SystemPerformanceInformation _spi;
    private NativeStructs.SystemBasicInformation _sbi;
    private NativeStructs.SystemCacheInformation _ci;
    private NativeStructs.SystemProcessorPerformanceInformation[] _ppi;
    private decimal _totPhysMem;

    // ========================================
    // Properties
    // ========================================
    public decimal TotalPhysicalMemory
    {
        get
        {
            if (_totPhysMem == 0)
                _totPhysMem = decimal.Multiply(_sbi.NumberOfPhysicalPages, _sbi.PageSize);
            return _totPhysMem;
        }
    }
    public int HandleCount
    {
        get
        {
            return _handles;
        }
    }
    public int ProcessCount
    {
        get
        {
            return _processes;
        }
    }
    public int ThreadCount
    {
        get
        {
            return _threads;
        }
    }
    public int ProcessorCount
    {
        get
        {
            return _processors;
        }
    }
    public int PhysicalPagesCount
    {
        get
        {
            return _physicalPagesCount;
        }
    }
    public int TimerResolution
    {
        get
        {
            return _timerResolution;
        }
    }
    public int CacheErrors
    {
        get
        {
            return _cacheErrors;
        }
    }
    public IntPtr CachePeak
    {
        get
        {
            return _peakCache;
        }
    }
    public IntPtr CacheMin
    {
        get
        {
            return _minCache;
        }
    }
    public IntPtr CacheCurrent
    {
        get
        {
            return _currentCache;
        }
    }
    public IntPtr CacheMax
    {
        get
        {
            return _maxCache;
        }
    }
    public NativeStructs.SystemPerformanceInformation PerformanceInformations
    {
        get
        {
            return _spi;
        }
    }
    public NativeStructs.SystemBasicInformation BasicInformations
    {
        get
        {
            return _sbi;
        }
    }
    public NativeStructs.SystemCacheInformation CacheInformations
    {
        get
        {
            return _ci;
        }
    }
    public NativeStructs.SystemProcessorPerformanceInformation[] ProcessorPerformanceInformations
    {
        get
        {
            return _ppi;
        }
    }
    public double PhysicalMemoryPercentageUsage
    {
        get
        {
            long totalMem = _sbi.NumberOfPhysicalPages;
            long usedMem = _sbi.NumberOfPhysicalPages - _spi.AvailablePages;
            if (totalMem > 0)
                return usedMem / (double)totalMem;
            else
                return 0;
        }
    }
    public double CpuUsage
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
            Static oldDate As Date = Date.Now

 */
            DateTime newDate = DateTime.Now;
            DateTime diff;
            long ticks = newDate.Ticks - oldDate.Ticks;

            if (ticks >= DateTime.MinValue.Ticks && ticks <= DateTime.MaxValue.Ticks)
                diff = new DateTime(ticks);
            else
                diff = new DateTime(DateTime.Now.Ticks);

            oldDate = newDate;

            long zres0 = 0;
            long zres1 = 0;
            long zres2 = 0;
            long zres3 = 0;
            long zres4 = 0;
            long zres5 = 0;
            var loopTo = _ppi.Length - 1;
            for (int x = 0; x <= loopTo; x++)
            {
                zres0 += _ppi[x].InterruptCount;
                zres1 += System.Convert.ToInt64(_ppi[x].IdleTime / (double)_processors);
                zres2 += System.Convert.ToInt64(_ppi[x].InterruptTime / (double)_processors);
                zres3 += System.Convert.ToInt64(_ppi[x].UserTime / (double)_processors);
                zres4 += System.Convert.ToInt64(_ppi[x].DpcTime / (double)_processors);
                zres5 += System.Convert.ToInt64(_ppi[x].KernelTime / (double)_processors);
            };/* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
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
            long newProcTime = zres3 + zres5 - zres1;
            long diffProcTime = newProcTime - oldProcTime;

            if (oldProcTime > 0)
            {
                oldProcTime = newProcTime;
                if (diff.Ticks > 0 & _processors > 0)
                    return diffProcTime / (double)diff.Ticks; // / _processors
                else
                    return 0;
            }
            else
            {
                oldProcTime = newProcTime;
                return 0;
            }
        }
    }


    // ========================================
    // Public functions
    // ========================================

    // Get number of processors
    public static int GetProcessorCount()
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
        Static _count As Integer = 0

 */
        if (_count == 0)
        {
            NativeStructs.SystemBasicInformation bi = new NativeStructs.SystemBasicInformation();
            int ret;
            NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemBasicInformation, ref bi, Marshal.SizeOf(bi), ref ret);
            _count = bi.NumberOfProcessors;
        }
        return _count;
    }

    public cSystemInfo() : base()
    {

        // Basic informations (do not change)
        NativeStructs.SystemBasicInformation bi = new NativeStructs.SystemBasicInformation();
        int ret;
        NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemBasicInformation, ref bi, Marshal.SizeOf(bi), ref ret);
        {
            var withBlock = bi;
            _physicalPagesCount = withBlock.NumberOfPhysicalPages;
            _processors = withBlock.NumberOfProcessors;
            _timerResolution = withBlock.TimerResolution;
        }
        _sbi = bi;

        RefreshInfo();
    }
    public void RefreshInfo()
    {
        int ret;

        NativeStructs.PerformanceInformation pi = new NativeStructs.PerformanceInformation();
        NativeFunctions.GetPerformanceInfo(out pi, Marshal.SizeOf(pi));
        {
            var withBlock = pi;
            _threads = withBlock.ThreadCount;
            _handles = withBlock.HandlesCount;
            _processes = withBlock.ProcessCount;
        }

        NativeStructs.SystemCacheInformation ci = new NativeStructs.SystemCacheInformation();
        NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemFileCacheInformation, ref ci, Marshal.SizeOf(ci), ref ret);
        {
            var withBlock1 = ci;
            _currentCache = withBlock1.SystemCacheWsSize;
            _peakCache = withBlock1.SystemCacheWsPeakSize;
            _cacheErrors = withBlock1.SystemCacheWsFaults;
            _minCache = withBlock1.SystemCacheWsMinimum;
            _maxCache = withBlock1.SystemCacheWsMaximum;
        }
        _ci = ci;

        NativeStructs.SystemPerformanceInformation spi = new NativeStructs.SystemPerformanceInformation();
        NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemPerformanceInformation, ref spi, Marshal.SizeOf(spi), ref ret);
        _spi = spi;

        if (_processors > 0)
        {
            _ppi = new NativeStructs.SystemProcessorPerformanceInformation[_processors - 1 + 1];
            int __size = _processors * Marshal.SizeOf(_ppi[0]);
            // PERFISSUE : WE MUST NOT ALLOCATE EACH TIME
            using (Native.Memory.MemoryAlloc memAlloc = new Native.Memory.MemoryAlloc(__size))
            {
                NativeFunctions.NtQuerySystemInformation(NativeEnums.SystemInformationClass.SystemProcessorPerformanceInformation, memAlloc.Pointer, __size, ref ret);
                var loopTo = _processors - 1;

                // Conversion from unmanaged memory to valid array
                for (int x = 0; x <= loopTo; x++)
                    _ppi[x] = memAlloc.ReadStruct<NativeStructs.SystemProcessorPerformanceInformation>(0, x);
            }
        }
        else
            _ppi = new NativeStructs.SystemProcessorPerformanceInformation[1];
    }
}

