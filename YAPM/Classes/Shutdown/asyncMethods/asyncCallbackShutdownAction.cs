using Common;
using System;

public class asyncCallbackShutdownAction
{
    private cShutdownConnection con;
    private HasShutdowned _deg;

    public delegate void HasShutdowned(bool Success, Native.Api.Enums.ShutdownType type, string msg);

    public asyncCallbackShutdownAction(HasShutdowned deg, ref cShutdownConnection shutConnection)
    {
        _deg = deg;
        con = shutConnection;
    }

    public struct poolObj
    {
        public Native.Api.Enums.ShutdownType type;
        public bool force;
        public poolObj(Native.Api.Enums.ShutdownType _type, bool _force)
        {
            force = _force;
            type = _type;
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
                        cSocketData.OrderType order;
                        switch (pObj.type)
                        {
                            case Native.Api.Enums.ShutdownType.Lock:
                                {
                                    order = cSocketData.OrderType.GeneralCommandLock;
                                    break;
                                }

                            case Native.Api.Enums.ShutdownType.Logoff:
                                {
                                    order = cSocketData.OrderType.GeneralCommandLogoff;
                                    break;
                                }

                            case Native.Api.Enums.ShutdownType.Poweroff:
                                {
                                    order = cSocketData.OrderType.GeneralCommandPoweroff;
                                    break;
                                }

                            case Native.Api.Enums.ShutdownType.Restart:
                                {
                                    order = cSocketData.OrderType.GeneralCommandRestart;
                                    break;
                                }

                            case Native.Api.Enums.ShutdownType.Shutdown:
                                {
                                    order = cSocketData.OrderType.GeneralCommandShutdown;
                                    break;
                                }

                            case Native.Api.Enums.ShutdownType.Sleep:
                                {
                                    order = cSocketData.OrderType.GeneralCommandSleep;
                                    break;
                                }

                            case Native.Api.Enums.ShutdownType.Hibernate:
                                {
                                    order = cSocketData.OrderType.GeneralCommandHibernate;
                                    break;
                                }
                        }
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, order, pObj.force);
                        con.ConnectionObj.Socket.Send(cDat);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowError(ex, "Could not launch shutdown command");
                    }

                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    string msg = "";
                    bool ret = Wmi.Objects.cSystem.ShutdownRemoteComputer(pObj.type, pObj.force, con.wmiSearcher, ref msg);
                    try
                    {
                        _deg.Invoke(ret, pObj.type, msg);
                    }
                    catch (Exception ex)
                    {
                        _deg.Invoke(false, pObj.type, ex.Message);
                    }

                    break;
                }

            default:
                {
                    // Local
                    bool ret;
                    switch (pObj.type)
                    {
                        case Native.Api.Enums.ShutdownType.Lock:
                            {
                                ret = cSystem.Lock();
                                break;
                            }

                        case Native.Api.Enums.ShutdownType.Logoff:
                            {
                                ret = cSystem.Logoff(pObj.force);
                                break;
                            }

                        case Native.Api.Enums.ShutdownType.Poweroff:
                            {
                                ret = cSystem.Poweroff(pObj.force);
                                break;
                            }

                        case Native.Api.Enums.ShutdownType.Restart:
                            {
                                ret = cSystem.Restart(pObj.force);
                                break;
                            }

                        case Native.Api.Enums.ShutdownType.Shutdown:
                            {
                                ret = cSystem.Shutdown(pObj.force);
                                break;
                            }

                        case Native.Api.Enums.ShutdownType.Sleep:
                            {
                                ret = cSystem.Sleep(pObj.force);
                                break;
                            }

                        case Native.Api.Enums.ShutdownType.Hibernate:
                            {
                                ret = cSystem.Hibernate(pObj.force);
                                break;
                            }
                    }
                    _deg.Invoke(ret, pObj.type, Native.Api.Win32.GetLastError());
                    break;
                }
        }
    }
}

