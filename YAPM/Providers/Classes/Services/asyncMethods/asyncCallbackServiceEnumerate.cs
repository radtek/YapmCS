using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackServiceEnumerate
{
    public static void ClearDico()
    {
        Native.Objects.Service.ClearNewServicesList();
    }


    private Control ctrl;
    private Delegate deg;
    private cServiceConnection con;
    private int _instanceId;

    public asyncCallbackServiceEnumerate(ref Control ctr, Delegate de, ref cServiceConnection co, int iId)
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
        public bool complete;
        public poolObj(int pi, bool al, bool comp, int forII)
        {
            all = al;
            forInstanceId = forII;
            pid = pi;
            complete = comp;
        }
    }


    // When socket got a list !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, serviceInfos> dico = new Dictionary<string, serviceInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (serviceInfos)lst[x]);
        }

        try
        {
            if (deg != null && ctrl.Created)
                ctrl.Invoke(deg, true, dico, null, _instanceId);
        }
        catch (Exception ex)
        {
            Misc.ShowDebugError(ex);
        }
    }
    public static System.Threading.Semaphore sem = new System.Threading.Semaphore(1, 1);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestServiceList, pObj.pid, pObj.all);
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

                    // Save current collection
                    Dictionary<string, serviceInfos> _dico = new Dictionary<string, serviceInfos>();
                    bool res;
                    string msg = "";

                    res = Wmi.Objects.Service.EnumerateProcesses(pObj.pid, pObj.all, con.wmiSearcher, ref _dico, ref msg);
                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, res, _dico, msg, 0);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }

            case cConnection.TypeOfConnection.SnapshotFile:
                {
                    // Snapshot file

                    Dictionary<string, serviceInfos> _dico = new Dictionary<string, serviceInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                    {
                        if (pObj.all)
                            // All services
                            _dico = snap.Services;
                        else
                            // For one process only
                            _dico = snap.ServicesByProcessId(pObj.pid);
                    }
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

                    Dictionary<string, serviceInfos> _dico = new Dictionary<string, serviceInfos>();

                    Native.Objects.Service.EnumerateServices(con.SCManagerLocalHandle, ref _dico, pObj.all, pObj.complete, pObj.pid);

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
    public static Dictionary<string, serviceInfos> SharedLocalSyncEnumerate(poolObj pObj, cServiceConnection con)
    {
        Dictionary<string, serviceInfos> _dico = new Dictionary<string, serviceInfos>();

        Native.Objects.Service.EnumerateServices(con.SCManagerLocalHandle, ref _dico, pObj.all, pObj.complete, pObj.pid);

        return _dico;
    }
}

