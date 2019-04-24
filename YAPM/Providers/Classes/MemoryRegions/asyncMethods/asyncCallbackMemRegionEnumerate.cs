using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackMemRegionEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cMemRegionConnection con;
    private int _instanceId;
    public asyncCallbackMemRegionEnumerate(ref Control ctr, Delegate de, ref cMemRegionConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int pid;
        public int forInstanceId;
        public poolObj(int pi, int ii)
        {
            forInstanceId = ii;
            pid = pi;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, memRegionInfos> dico = new Dictionary<string, memRegionInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (memRegionInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestMemoryRegionList, pObj.pid);
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

                    Dictionary<string, memRegionInfos> _dico = new Dictionary<string, memRegionInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        // For some processes only
                        _dico = snap.MemoryRegionsByProcessId(pObj.pid);
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

                    Dictionary<string, memRegionInfos> _dico = new Dictionary<string, memRegionInfos>();

                    Native.Objects.MemRegion.EnumerateMemoryRegionsByProcessId(pObj.pid, ref _dico);

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
    public static Dictionary<string, memRegionInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, memRegionInfos> _dico = new Dictionary<string, memRegionInfos>();
        Native.Objects.MemRegion.EnumerateMemoryRegionsByProcessId(pObj.pid, ref _dico);
        return _dico;
    }
}

