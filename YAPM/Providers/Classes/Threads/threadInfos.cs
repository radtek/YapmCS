using System.Diagnostics;
using System;

[Serializable()]
public class threadInfos : generalInfos
{
    private IntPtr _AffinityMask;
    private long _KernelTime;
    private long _UserTime;
    private long _CreateTime;
    private int _WaitTime;
    private IntPtr _StartAddress;
    private int _Id;
    private int _ProcessId;
    private int _Priority;
    private int _BasePriority;
    private int _ContextSwitchCount;
    private ThreadState _State;
    private Native.Api.NativeEnums.KwaitReason _WaitReason;



    public long TotalTime
    {
        get
        {
            return _KernelTime + _UserTime;
        }
    }
    public long KernelTime
    {
        get
        {
            return _KernelTime;
        }
    }
    public long UserTime
    {
        get
        {
            return _UserTime;
        }
    }
    public long CreateTime
    {
        get
        {
            return _CreateTime;
        }
    }
    public int WaitTime
    {
        get
        {
            return _WaitTime;
        }
    }
    public IntPtr StartAddress
    {
        get
        {
            return _StartAddress;
        }
    }
    public int Id
    {
        get
        {
            return _Id;
        }
    }
    public int ProcessId
    {
        get
        {
            return _ProcessId;
        }
    }
    public System.Diagnostics.ThreadPriorityLevel Priority
    {
        get
        {
            return Native.Functions.Thread.GetThreadPriorityClassFromInt(_Priority);
        }
    }
    public System.Diagnostics.ThreadPriorityLevel BasePriority
    {
        get
        {
            return Native.Functions.Thread.GetThreadPriorityClassFromInt(_BasePriority);
        }
    }
    public int ContextSwitchCount
    {
        get
        {
            return _ContextSwitchCount;
        }
    }
    public ThreadState State
    {
        get
        {
            return _State;
        }
    }
    public Native.Api.NativeEnums.KwaitReason WaitReason
    {
        get
        {
            return _WaitReason;
        }
    }

    public int ContextSwitchDelta
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
            Static oldCount As Integer = Me.ContextSwitchCount

 */
            int res = this.ContextSwitchCount - oldCount;
            oldCount = this.ContextSwitchCount;
            return res;
        }
    }

    internal void SetPriority(int i)
    {
        _Priority = i;
    }



    public IntPtr AffinityMask
    {
        get
        {
            return _AffinityMask;
        }
        set
        {
            _AffinityMask = value;
        }
    }



    // ========================================
    // Public
    // ========================================

    // Constructor of this class
    public threadInfos()
    {
    }
    public threadInfos(ref Native.Api.NativeStructs.SystemThreadInformation Thr)
    {
        {
            var withBlock = Thr;
            _AffinityMask = IntPtr.Zero;
            _Id = withBlock.ClientId.UniqueThread.ToInt32();
            _ProcessId = withBlock.ClientId.UniqueProcess.ToInt32();
            _BasePriority = withBlock.BasePriority;
            _ContextSwitchCount = withBlock.ContextSwitchCount;
            _CreateTime = withBlock.CreateTime;
            _KernelTime = withBlock.KernelTime;
            _Priority = withBlock.Priority;
            _StartAddress = withBlock.StartAddress;
            _State = withBlock.State;
            _UserTime = withBlock.UserTime;
            _WaitReason = withBlock.WaitReason;
            _WaitTime = withBlock.WaitTime;
        }
    }

    // Merge an old and a new instance
    public void Merge(ref threadInfos newI)
    {
        {
            var withBlock = newI;
            _AffinityMask = withBlock.AffinityMask;
            _BasePriority = withBlock.BasePriority;
            _ContextSwitchCount = withBlock.ContextSwitchCount;
            _CreateTime = withBlock.CreateTime;
            _KernelTime = withBlock.KernelTime;
            _Priority = withBlock.Priority;
            _State = withBlock.State;
            _UserTime = withBlock.UserTime;
            _WaitReason = withBlock.WaitReason;
            _WaitTime = withBlock.WaitTime;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[14];

        s[0] = "Priority";
        s[1] = "State";
        s[2] = "WaitReason";
        s[3] = "CreateTime";
        s[4] = "KernelTime";
        s[5] = "UserTime";
        s[6] = "WaitTime";
        s[7] = "TotalTime";
        s[8] = "StartAddress";
        s[9] = "BasePriority";
        s[10] = "AffinityMask";
        s[11] = "ContextSwitchCount";
        s[12] = "ContextSwitchDelta";
        s[13] = "ProcessId";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Id";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

