using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackHeapEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cHeapConnection con;
    private int _instanceId;
    public asyncCallbackHeapEnumerate(ref Control ctr, Delegate de, ref cHeapConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public int forInstanceId;
        public int pid;
        public poolObj(int pi, int iid)
        {
            forInstanceId = iid;
            pid = pi;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, heapInfos> dico = new Dictionary<string, heapInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (heapInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestHeapList, pObj.pid);
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

                    Dictionary<string, heapInfos> _dico = new Dictionary<string, heapInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.HeapsByProcessId(pObj.pid);
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
                    Dictionary<string, heapInfos> _dico = Native.Objects.Heap.EnumerateHeapsByProcessId(pObj.pid);

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
    public static Dictionary<string, heapInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        return Native.Objects.Heap.EnumerateHeapsByProcessId(pObj.pid);
    }
}

