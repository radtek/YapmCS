using System.Collections.Generic;

public class cTask : cWindow
{
    private taskInfos _taskinfos;

    private int _pid;
    private cProcess _process;
    private bool _retried = false;

    private static Dictionary<string, cProcess> _procList;


    public cTask(ref windowInfos infos) : base(ref infos)
    {
        _pid = infos.ProcessId;
        _taskinfos = new taskInfos(ref infos);
        _TypeOfObject = Native.Api.Enums.GeneralObjectType.Task;

        // Get process from process list
        if (_procList != null)
        {
            if (_procList.Count == 0)
                // When we have disconnected (no more processes)
                _procList = null;
            else if (_procList.ContainsKey(_pid.ToString()))
                _process = _procList[_pid.ToString()];
        }
    }



    public new taskInfos Infos
    {
        get
        {
            return _taskinfos;
        }
    }

    public static Dictionary<string, cProcess> ProcessCollection
    {
        get
        {
            return _procList;
        }
        set
        {
            _procList = value;
        }
    }



    public double CpuUsage
    {
        get
        {
            if (_process != null)
                return _process.CpuUsage;
            else
// _process does not exist -> we try to get it
if (_procList != null)
            {
                if (_retried == false)
                {
                    // We have a list and we never tried to get _process -> do it
                    if (_procList.ContainsKey(_pid.ToString()))
                        _process = _procList[_pid.ToString()];
                    _retried = true;
                }
            }

            return 0;
        }
    }




    // Return list of available properties
    public override string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        return taskInfos.GetAvailableProperties(includeFirstProp, sorted);
    }

    // Retrieve informations by its name
    public override bool GetInformation(string info, ref string res)
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

        ' Old values (from last refresh)
        Static _old_CpuUsage As String = ""

 */
        bool hasChanged = true;

        switch (info)
        {
            case "CpuUsage":
                {
                    res = Common.Misc.GetFormatedPercentage(this.CpuUsage);
                    if (res == _old_CpuUsage)
                        hasChanged = false;
                    else
                        _old_CpuUsage = res;
                    break;
                }

            default:
                {
                    return base.GetInformation(info, ref res);
                }
        }

        return hasChanged;
    }
    public override string GetInformation(string info)
    {
        switch (info)
        {
            case "CpuUsage":
                {
                    return Common.Misc.GetFormatedPercentage(this.CpuUsage);
                }

            default:
                {
                    return base.GetInformation(info);
                }
        }
    }
}

