﻿using Common;
using System;

public class asyncCallbackServiceStop
{
    private cServiceConnection con;
    private HasStopped _deg;

    public delegate void HasStopped(bool Success, string name, string msg, int actionNumber);

    public asyncCallbackServiceStop(HasStopped deg, ref cServiceConnection procConnection)
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ServiceStop, pObj.name);
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
                    res = Wmi.Objects.Service.StopServiceByName(pObj.name, con.wmiSearcher, ref msg);

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
                    bool res = Native.Objects.Service.StopServiceByName(pObj.name, con.SCManagerLocalHandle);
                    _deg.Invoke(res, pObj.name, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

