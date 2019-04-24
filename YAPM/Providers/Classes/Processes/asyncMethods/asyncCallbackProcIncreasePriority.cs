using System.Diagnostics;
using Common;
using System;

public class asyncCallbackProcIncreasePriority
{
    private cProcessConnection con;
    private HasIncreasedPriority _deg;

    public delegate void HasIncreasedPriority(bool Success, string msg, int actionN);

    public asyncCallbackProcIncreasePriority(HasIncreasedPriority deg, ref cProcessConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int pid;
        public int newAction;
        public int level;
        public poolObj(int pi, int _level, int act)
        {
            level = _level;
            newAction = act;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessIncreasePriority, pObj.pid);
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
                    ProcessPriorityClass _newlevel;
                    switch (pObj.level)
                    {
                        case ProcessPriorityClass.AboveNormal:
                            {
                                _newlevel = ProcessPriorityClass.High;
                                break;
                            }

                        case ProcessPriorityClass.BelowNormal:
                            {
                                _newlevel = ProcessPriorityClass.Normal;
                                break;
                            }

                        case ProcessPriorityClass.High:
                            {
                                _newlevel = ProcessPriorityClass.RealTime;
                                break;
                            }

                        case ProcessPriorityClass.Idle:
                            {
                                _newlevel = ProcessPriorityClass.BelowNormal;
                                break;
                            }

                        case ProcessPriorityClass.Normal:
                            {
                                _newlevel = ProcessPriorityClass.AboveNormal;
                                break;
                            }

                        case ProcessPriorityClass.RealTime:
                            {
                                break;
                            }
                    }

                    string msg = "";
                    bool ret = Wmi.Objects.Process.SetProcessPriorityById(pObj.pid, _newlevel, con.wmiSearcher, ref msg);
                    try
                    {
                        _deg.Invoke(ret, msg, pObj.newAction);
                    }
                    catch (Exception ex)
                    {
                        _deg.Invoke(false, ex.Message, pObj.newAction);
                    }

                    break;
                }

            default:
                {
                    // Local
                    ProcessPriorityClass _newlevel;
                    switch (pObj.level)
                    {
                        case ProcessPriorityClass.AboveNormal:
                            {
                                _newlevel = ProcessPriorityClass.High;
                                break;
                            }

                        case ProcessPriorityClass.BelowNormal:
                            {
                                _newlevel = ProcessPriorityClass.Normal;
                                break;
                            }

                        case ProcessPriorityClass.High:
                            {
                                _newlevel = ProcessPriorityClass.RealTime;
                                break;
                            }

                        case ProcessPriorityClass.Idle:
                            {
                                _newlevel = ProcessPriorityClass.BelowNormal;
                                break;
                            }

                        case ProcessPriorityClass.Normal:
                            {
                                _newlevel = ProcessPriorityClass.AboveNormal;
                                break;
                            }

                        case ProcessPriorityClass.RealTime:
                            {
                                break;
                            }
                    }
                    bool r = Native.Objects.Process.SetProcessPriorityById(pObj.pid, _newlevel);
                    _deg.Invoke(r, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

