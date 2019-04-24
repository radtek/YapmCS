using System.Diagnostics;
using Common;
using System;

public class asyncCallbackThreadIncreasePriority
{
    private cThreadConnection con;
    private HasIncreasedPriority _deg;

    public delegate void HasIncreasedPriority(bool Success, string msg, int actionNumber);

    public struct poolObj
    {
        public int id;
        public int level;
        public int pid;
        public int newAction;
        public poolObj(int _id, int _level, int action, int processId = 0)
        {
            newAction = action;
            id = _id;
            level = _level;
            pid = processId;
        }
    }

    public asyncCallbackThreadIncreasePriority(HasIncreasedPriority deg, ref cThreadConnection procConnection)
    {
        _deg = deg;
        con = procConnection;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ThreadIncreasePriority, pObj.pid, pObj.id, pObj.level);
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
                                _level2 = ThreadPriorityLevel.Highest;
                                break;
                            }

                        case ThreadPriorityLevel.BelowNormal:
                            {
                                _level2 = ThreadPriorityLevel.Normal;
                                break;
                            }

                        case ThreadPriorityLevel.Highest:
                            {
                                _level2 = ThreadPriorityLevel.TimeCritical;
                                break;
                            }

                        case ThreadPriorityLevel.Idle:
                            {
                                _level2 = ThreadPriorityLevel.Lowest;
                                break;
                            }

                        case ThreadPriorityLevel.Lowest:
                            {
                                _level2 = ThreadPriorityLevel.BelowNormal;
                                break;
                            }

                        case ThreadPriorityLevel.Normal:
                            {
                                _level2 = ThreadPriorityLevel.AboveNormal;
                                break;
                            }

                        case ThreadPriorityLevel.TimeCritical:
                            {
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

