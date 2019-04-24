using System.Diagnostics;
using Common;
using System;

public class asyncCallbackThreadDecreasePriority
{
    private cThreadConnection con;
    private HasDecreasedPriority _deg;

    public delegate void HasDecreasedPriority(bool Success, string msg, int actionNumber);

    public asyncCallbackThreadDecreasePriority(HasDecreasedPriority deg, ref cThreadConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public int id;
        public int level;
        public int newAction;
        public int pid;
        public poolObj(int _id, int _level, int action, int processId = 0)
        {
            newAction = action;
            id = _id;
            level = _level;
            pid = processId;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ThreadDecreasePriority, pObj.pid, pObj.id, pObj.level);
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
                    System.Diagnostics.ThreadPriorityLevel _level2;
                    switch (pObj.level)
                    {
                        case ThreadPriorityLevel.AboveNormal:
                            {
                                _level2 = ThreadPriorityLevel.Normal;
                                break;
                            }

                        case ThreadPriorityLevel.BelowNormal:
                            {
                                _level2 = ThreadPriorityLevel.Lowest;
                                break;
                            }

                        case ThreadPriorityLevel.Highest:
                            {
                                _level2 = ThreadPriorityLevel.AboveNormal;
                                break;
                            }

                        case ThreadPriorityLevel.Idle:
                            {
                                break;
                            }

                        case ThreadPriorityLevel.Lowest:
                            {
                                _level2 = ThreadPriorityLevel.Idle;
                                break;
                            }

                        case ThreadPriorityLevel.Normal:
                            {
                                _level2 = ThreadPriorityLevel.BelowNormal;
                                break;
                            }

                        case ThreadPriorityLevel.TimeCritical:
                            {
                                _level2 = ThreadPriorityLevel.Highest;
                                break;
                            }
                    }

                    bool r = Native.Objects.Thread.SetThreadPriorityById(pObj.id, _level2);
                    _deg.Invoke(r, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

