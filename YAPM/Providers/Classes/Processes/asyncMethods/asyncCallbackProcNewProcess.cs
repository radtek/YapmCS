using Microsoft.VisualBasic;
using Common;
using System;

public class asyncCallbackProcNewProcess
{
    private cProcessConnection con;
    private HasCreated _deg;

    public delegate void HasCreated(bool Success, string path, string msg, int actionN);

    public asyncCallbackProcNewProcess(HasCreated deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public string path;
        public int newAction;
        public poolObj(string s, int act)
        {
            newAction = act;
            path = s;
        }
    }

    public void Process(object thePoolObj)
    {
        poolObj pObj = (poolObj)thePoolObj;
        if (con.ConnectionObj.IsConnected == false)
            return;

        switch (con.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    try
                    {
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessCreateNew, pObj.path);
                        con.ConnectionObj.Socket.Send(cDat);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowError(ex, "Unable to send request to server");
                    }

                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    string msg = "";
                    bool res = Wmi.Objects.Process.CreateNewProcessByPath(pObj.path, con.wmiSearcher, ref msg);
                    try
                    {
                        _deg.Invoke(res, pObj.path, msg, pObj.newAction);
                    }
                    catch (Exception ex)
                    {
                        _deg.Invoke(false, pObj.path, ex.Message, pObj.newAction);
                    }

                    break;
                }

            default:
                {
                    // Local
                    // OK, normally the local startNewProcess is not done here
                    // because of RunBox need
                    int pid = Interaction.Shell(pObj.path);
                    _deg.Invoke(pid != 0, pObj.path, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}
