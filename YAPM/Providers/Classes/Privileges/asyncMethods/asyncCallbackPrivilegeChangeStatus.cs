using Common;
using System;

public class asyncCallbackPrivilegeChangeStatus
{
    private cPrivilegeConnection con;
    private HasChangedStatus _deg;

    public delegate void HasChangedStatus(bool Success, int pid, string name, string msg, int actionNumber);

    public asyncCallbackPrivilegeChangeStatus(HasChangedStatus deg, ref cPrivilegeConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public string name;
        public Native.Api.NativeEnums.SePrivilegeAttributes status;
        public int newAction;
        public poolObj(int pi, string nam, Native.Api.NativeEnums.SePrivilegeAttributes stat, int act)
        {
            name = nam;
            newAction = act;
            status = stat;
            pid = pi;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.PrivilegeChangeStatus, pObj.pid, pObj.name, pObj.status);
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
                    break;
                }

            default:
                {
                    // Local
                    bool ret = Native.Objects.Token.SetPrivilegeStatusByProcessId(pObj.pid, pObj.name, pObj.status);
                    _deg.Invoke(ret, pObj.pid, pObj.name, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

