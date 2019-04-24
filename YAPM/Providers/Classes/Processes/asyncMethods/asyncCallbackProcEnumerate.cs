using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackProcEnumerate
{
    private Native.Security.ProcessAccess processMinRights = Native.Security.ProcessAccess.QueryInformation;

    private Control ctrl;
    private Delegate deg;
    private cProcessConnection con;
    private int _instanceId;
    public asyncCallbackProcEnumerate(ref Control ctr, Delegate de, ref cProcessConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
        if (cEnvironment.SupportsMinRights)
            processMinRights = Native.Security.ProcessAccess.QueryLimitedInformation;
    }


    // Reanalize a process by removing (or asking to remove) its PID from
    // the shared dictionnary of known PID
    public struct ReanalizeProcessObj
    {
        public int[] pid;
        public cProcessConnection con;
        public ReanalizeProcessObj(ref int[] pi, ref cProcessConnection co)
        {
            pid = pi;
            con = co;
        }
    }
    public static void ReanalizeProcess(object thePoolObj)
    {
        sem.WaitOne();

        ReanalizeProcessObj pObj = (ReanalizeProcessObj)thePoolObj;
        if (pObj.con.ConnectionObj.IsConnected == false)
        {
            sem.Release();
            return;
        }

        switch (pObj.con.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    try
                    {
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ProcessReanalize, pObj.pid);
                        pObj.con.ConnectionObj.Socket.Send(cDat);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowError(ex, "Unable to send request to server");
                    }

                    break;
                }

            case cConnection.TypeOfConnection.LocalConnection:
            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    Native.Objects.Process.SemNewProcesses.WaitOne();
                    foreach (int id in pObj.pid)
                    {
                        if (Native.Objects.Process.NewProcesses.ContainsKey(id))
                            Native.Objects.Process.NewProcesses.Remove(id);
                    }
                    Native.Objects.Process.SemNewProcesses.Release();
                    break;
                }
        }

        sem.Release();
    }

    // Called to remove PIDs from shared dico by the server after it receive
    // a command to reanalize some PIDs
    public static void ReanalizeLocalAfterSocket(ref int[] pid)
    {
        Native.Objects.Process.SemNewProcesses.WaitOne();
        foreach (int id in pid)
        {
            if (Native.Objects.Process.NewProcesses.ContainsKey(id))
                Native.Objects.Process.NewProcesses.Remove(id);
        }
        Native.Objects.Process.SemNewProcesses.Release();
    }


    public struct poolObj
    {
        public ProcessEnumMethode method;
        public int forInstanceId;
        public bool force;
        public poolObj(int iid, ProcessEnumMethode tmethod = ProcessEnumMethode.VisibleProcesses, bool forceAllInfos = false)
        {
            forInstanceId = iid;
            method = tmethod;
            force = forceAllInfos;
        }
    }
    public enum ProcessEnumMethode : int
    {
        VisibleProcesses,
        BruteForce,
        HandleMethod
    }


    // When socket got a list of processes !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, processInfos> dico = new Dictionary<string, processInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
            {
                if (dico.ContainsKey(keys[x]) == false)
                    dico.Add(keys[x], (processInfos)lst[x]);
            }
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

    internal static System.Threading.Semaphore sem = new System.Threading.Semaphore(1, 1);
    public void Process(object thePoolObj)
    {
        sem.WaitOne();

        Native.Objects.Process.SemNewProcesses.WaitOne();

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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestProcessList);
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
                    Dictionary<string, processInfos> _dico = new Dictionary<string, processInfos>();
                    string msg = "";
                    bool res = Wmi.Objects.Process.EnumerateProcesses(con.wmiSearcher, ref _dico, ref msg);

                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, res, _dico, msg, pObj.forInstanceId);
                    }
                    catch (Exception ex)
                    {
                        Misc.ShowDebugError(ex);
                    }

                    break;
                }

            case cConnection.TypeOfConnection.SnapshotFile:
                {
                    // Snapshot

                    Dictionary<string, processInfos> _dico = new Dictionary<string, processInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        _dico = snap.Processes;
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
                    Dictionary<string, processInfos> _dico;

                    switch (pObj.method)
                    {
                        case ProcessEnumMethode.BruteForce:
                            {
                                _dico = Native.Objects.Process.EnumerateHiddenProcessesBruteForce();
                                break;
                            }

                        case ProcessEnumMethode.HandleMethod:
                            {
                                _dico = Native.Objects.Process.EnumerateHiddenProcessesHandleMethod();
                                break;
                            }

                        default:
                            {
                                _dico = Native.Objects.Process.EnumerateVisibleProcesses(pObj.force);
                                break;
                            }
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
        }

        Native.Objects.Process.SemNewProcesses.Release();
        sem.Release();
    }

    // Shared, local and sync enumeration
    public static Dictionary<string, processInfos> SharedLocalSyncEnumerate(bool forceAllInfos, poolObj pObj)
    {
        Dictionary<string, processInfos> _dico;

        switch (pObj.method)
        {
            case ProcessEnumMethode.BruteForce:
                {
                    _dico = Native.Objects.Process.EnumerateHiddenProcessesBruteForce();
                    break;
                }

            case ProcessEnumMethode.HandleMethod:
                {
                    _dico = Native.Objects.Process.EnumerateHiddenProcessesHandleMethod();
                    break;
                }

            default:
                {
                    _dico = Native.Objects.Process.EnumerateVisibleProcesses(forceAllInfos);
                    break;
                }
        }

        return _dico;
    }
}

