using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackWindowEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cWindowConnection con;
    private int _instanceId;
    public asyncCallbackWindowEnumerate(ref Control ctr, Delegate de, ref cWindowConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int pid;
        public bool all;
        public int forInstanceId;
        public bool unnamed;
        public poolObj(ref int pi, bool al, bool unn, int ii)
        {
            forInstanceId = ii;
            pid = pi;
            all = al;
            unnamed = unn;
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestWindowList, pObj.pid, pObj.unnamed, pObj.all);
                        cDat.InstanceId = _instanceId;   // Instance which request the list
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
                    // Snapshot

                    Dictionary<string, windowInfos> _dico = new Dictionary<string, windowInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.WindowsByProcessId(pObj.pid);
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
                    Dictionary<string, windowInfos> _dico = new Dictionary<string, windowInfos>();

                    Native.Objects.Window.EnumerateWindowsByProcessId(pObj.pid, pObj.all, pObj.unnamed, ref _dico, Program.Parameters.ModeServer);

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
    public static Dictionary<string, windowInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, windowInfos> _dico = new Dictionary<string, windowInfos>();
        Native.Objects.Window.EnumerateWindowsByProcessId(pObj.pid, pObj.all, pObj.unnamed, ref _dico, Program.Parameters.ModeServer);
        return _dico;
    }
}

