using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackNetworkEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cNetworkConnection con;
    private int _instanceId;
    public asyncCallbackNetworkEnumerate(ref Control ctr, Delegate de, ref cNetworkConnection co, int iId)
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
        public poolObj(ref int pi, bool al, int ii)
        {
            forInstanceId = ii;
            pid = pi;
            all = al;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, networkInfos> dico = new Dictionary<string, networkInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (networkInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestNetworkConnectionList, pObj.pid, pObj.all);
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

                    Dictionary<string, networkInfos> _dico = new Dictionary<string, networkInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                    {
                        if (pObj.all)
                            // All connections
                            _dico = snap.NetworkConnections;
                        else
                            // For one process only
                            _dico = snap.NetworkConnectionsByProcessId(pObj.pid);
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

                    Dictionary<string, networkInfos> _dico = new Dictionary<string, networkInfos>();

                    // Enumeration
                    Native.Objects.Network.EnumerateTcpUdpConnections(ref _dico, pObj.all, pObj.pid);

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
    public static Dictionary<string, networkInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, networkInfos> _dico = new Dictionary<string, networkInfos>();

        Native.Objects.Network.EnumerateTcpUdpConnections(ref _dico, pObj.all, pObj.pid);

        return _dico;
    }
}

