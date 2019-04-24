using Common;
using System;
using Native.Objects;

public class asyncCallbackWindowAction
{
    private HasMadeAction _theDeg;
    private cWindowConnection con;

    public delegate void HasMadeAction(bool Success, Native.Api.Enums.AsyncWindowAction action, IntPtr handle, string msg, int actionNumber);

    public asyncCallbackWindowAction(HasMadeAction deg, ref cWindowConnection procConnection)
    {
        _theDeg = deg;
        con = procConnection;
    }

    public struct poolObj
    {
        public IntPtr handle;
        public int o1;
        public int o3;
        public int o2;
        public string s;
        public Native.Api.NativeStructs.Rect r;
        public Native.Api.Enums.AsyncWindowAction action;
        public int newAction;
        public poolObj(Native.Api.Enums.AsyncWindowAction _action, IntPtr _handle, int _o1, int _o2, int _o3, int act, object obj = null, string ss = null)
        {
            newAction = act;
            handle = _handle;
            action = _action;
            o1 = _o1;
            o2 = _o2;
            o3 = _o3;
            s = ss;
            if (obj != null)
                r = (Native.Api.NativeStructs.Rect)obj;
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
                        cSocketData cDat = null;
                        switch (pObj.action)
                        {
                            case Native.Api.Enums.AsyncWindowAction.BringToFront:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowBringToFront, pObj.handle, pObj.o1);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.Close:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowClose, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.Flash:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowFlash, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.Hide:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowHide, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.Maximize:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowMaximize, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.Minimize:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowMinimize, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.SendMessage:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowShow, pObj.handle, pObj.o1, pObj.o2, pObj.o3);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.SetAsActiveWindow:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowSetAsActiveWindow, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.SetAsForegroundWindow:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowSetAsForegroundWindow, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.SetEnabled:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowEnable, pObj.handle, System.Convert.ToBoolean(pObj.o1));
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.SetOpacity:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowEnable, pObj.handle, System.Convert.ToByte(pObj.o1));
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.Show:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowShow, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.StopFlashing:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowStopFlashing, pObj.handle);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.SetPosition:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowSetPositions, pObj.handle, pObj.r);
                                    break;
                                }

                            case Native.Api.Enums.AsyncWindowAction.SetCaption:
                                {
                                    cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.WindowSetCaption, pObj.handle, pObj.s);
                                    break;
                                }
                        }

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

                    bool res;
                    switch (pObj.action)
                    {
                        case Native.Api.Enums.AsyncWindowAction.BringToFront:
                            {
                                res = Window.BringWindowToFrontByHandle(pObj.handle, System.Convert.ToBoolean(pObj.o1));
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.Close:
                            {
                                res = Window.CloseWindowByHandle(pObj.handle);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.Flash:
                            {
                                res = Window.FlashWindowByHandle(pObj.handle, Native.Api.NativeEnums.FlashWInfoFlags.All);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.Hide:
                            {
                                res = Window.HideWindowByHandle(pObj.handle);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.Maximize:
                            {
                                res = Window.MaximizeWindowByHandle(pObj.handle);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.Minimize:
                            {
                                res = Window.MinimizeWindowByHandle(pObj.handle);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.SendMessage:
                            {
                                res = (Window.SendMessage(pObj.handle, (Native.Api.NativeEnums.WindowMessage)pObj.o1, new IntPtr(pObj.o2), new IntPtr(pObj.o3)).IsNotNull());
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.SetAsActiveWindow:
                            {
                                res = Window.SetActiveWindowByHandle(pObj.handle);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.SetAsForegroundWindow:
                            {
                                res = Window.SetForegroundWindowByHandle(pObj.handle);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.SetEnabled:
                            {
                                res = Window.EnableWindowByHandle(pObj.handle, System.Convert.ToBoolean(pObj.o1));
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.SetOpacity:
                            {
                                res = Window.SetWindowOpacityByHandle(pObj.handle, System.Convert.ToByte(pObj.o1));
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.Show:
                            {
                                res = Window.ShowWindowByHandle(pObj.handle);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.StopFlashing:
                            {
                                res = Window.FlashWindowByHandle(pObj.handle, Native.Api.NativeEnums.FlashWInfoFlags.Stop, 0);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.SetPosition:
                            {
                                res = Window.SetWindowPositionAndSizeByHandle(pObj.handle, pObj.r);
                                break;
                            }

                        case Native.Api.Enums.AsyncWindowAction.SetCaption:
                            {
                                res = Window.SetWindowCaptionByHandle(pObj.handle, pObj.s);
                                break;
                            }
                    }

                    _theDeg.Invoke(res, pObj.action, pObj.handle, Native.Api.Win32.GetLastError(), pObj.newAction);
                    break;
                }
        }
    }
}

