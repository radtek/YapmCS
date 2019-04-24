using Common;
using System;

public class asyncCallbackServiceSetStartType
{
    private static object _syncLockObj = new object();
    private cServiceConnection con;
    private HasChangedStartType _deg;

    public delegate void HasChangedStartType(bool Success, string name, string msg, int actionNumber);

    public asyncCallbackServiceSetStartType(HasChangedStartType deg, ref cServiceConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public string name;
        public Native.Api.NativeEnums.ServiceStartType type;
        public int newAction;
        public poolObj(string nam, Native.Api.NativeEnums.ServiceStartType typ, int act)
        {
            name = nam;
            newAction = act;
            type = typ;
        }
    }

    public void Process(object thePoolObj)
    {
        lock (_syncLockObj)
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
                            cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ServiceChangeServiceStartType, pObj.name, pObj.type);
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
                        bool res;
                        string msg = "";
                        res = Wmi.Objects.Service.SetServiceStartTypeByName(pObj.name, pObj.type, con.wmiSearcher, ref msg);

                        try
                        {
                            _deg.Invoke(res, pObj.name, msg, pObj.newAction);
                        }
                        catch (Exception ex)
                        {
                            Misc.ShowDebugError(ex);
                        }

                        break;
                    }

                default:
                    {
                        // Local
                        bool res = Native.Objects.Service.SetServiceStartTypeByName(pObj.name, pObj.type, con.SCManagerLocalHandle);
                        _deg.Invoke(res, pObj.name, Native.Api.Win32.GetLastError(), pObj.newAction);
                        break;
                    }
            }
        }
    }
}

