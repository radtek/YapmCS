using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;
using Native.Objects;

public class asyncCallbackTaskEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cTaskConnection con;
    private int _instanceId;
    public asyncCallbackTaskEnumerate(ref Control ctr, Delegate de, ref cTaskConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int forInstanceId;
        public poolObj(int ii)
        {
            forInstanceId = ii;
        }
    }

    // When socket got a list of processes !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, windowInfos> dico = new Dictionary<string, windowInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (windowInfos)lst[x]);
        }
        if (deg != null && ctrl.Created)
            ctrl.Invoke(deg, true, dico, null, _instanceId);
    }
    private static System.Threading.Semaphore sem = new System.Threading.Semaphore(1, 1);
    public void Process(object thePoolObj)
    {
        sem.WaitOne();

        poolObj pObj = (poolObj)thePoolObj;
        if (con.ConnectionObj.IsConnected == false)
        {
            sem.Release();
            return;
        }

        switch (con.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    _poolObj = pObj;
                    try
                    {
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestTaskList);
                        cDat.InstanceId = _instanceId;
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

            case cConnection.TypeOfConnection.SnapshotFile:
                {
                    // Snapshot file

                    Dictionary<string, windowInfos> _dico = new Dictionary<string, windowInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.Tasks;
                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, true, _dico, Native.Api.Win32.GetLastError(), pObj.forInstanceId);
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
                    Dictionary<string, windowInfos> _dico = SharedLocalSyncEnumerate();

                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, true, _dico, Native.Api.Win32.GetLastError(), pObj.forInstanceId);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }
        }

        sem.Release();
    }


    // Shared, local and sync enumeration
    public static Dictionary<string, windowInfos> SharedLocalSyncEnumerate()
    {
        IntPtr currWnd;
        int cpt;

        Dictionary<string, windowInfos> _dico = new Dictionary<string, windowInfos>();

        currWnd = Window.GetWindow(Window.GetDesktopWindow(), Native.Api.NativeEnums.GetWindowCmd.Child);
        cpt = 0;
        while (currWnd.IsNotNull())
        {
            if (Window.IsWindowATask(currWnd))
            {
                int pid = Window.GetProcessIdFromWindowHandle(currWnd);
                int tid = Window.GetThreadIdFromWindowHandle(currWnd);
                string key = pid.ToString() + "-" + tid.ToString() + "-" + currWnd.ToString();

                if (_dico.ContainsKey(key) == false)
                {
                    if (Program.Parameters.ModeServer)
                    {
                        // Then we need to retrieve all informations
                        // (this is server mode)
                        windowInfos wInfo;
                        wInfo = new windowInfos(pid, tid, currWnd, Window.GetWindowCaption(currWnd));
                        wInfo.SetNonFixedInfos(ref asyncCallbackWindowGetNonFixedInfos.ProcessAndReturnLocal(currWnd));
                        _dico.Add(key, wInfo);
                    }
                    else
                        _dico.Add(key, new windowInfos(pid, tid, currWnd, Window.GetWindowCaption(currWnd)));
                }
            }

            currWnd = Window.GetWindow(currWnd, Native.Api.NativeEnums.GetWindowCmd.Next);
        }

        return _dico;
    }
}

