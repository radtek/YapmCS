using Common;
using System;

public class asyncCallbackServiceDelete
{
    private cServiceConnection con;
    private HasDeleted _deg;

    public delegate void HasDeleted(bool Success, string name, string msg, int actionNumber);

    public asyncCallbackServiceDelete(HasDeleted deg, ref cServiceConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public string name;
        public int newAction;
        public poolObj(string nam, int act)
        {
            name = nam;
            newAction = act;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ServiceDelete, pObj.name);
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
                    bool res = Native.Objects.Service.DeleteServiceByName(pObj.name, con.SCManagerLocalHandle);
                    _deg.Invoke(res, pObj.name, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

