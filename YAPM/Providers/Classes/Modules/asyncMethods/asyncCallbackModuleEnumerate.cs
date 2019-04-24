using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackModuleEnumerate
{

    // Some material to retrieve infos about files ONCE
    internal static Dictionary<string, SerializableFileVersionInfo> fileInformations = new Dictionary<string, SerializableFileVersionInfo>();
    internal static System.Threading.Semaphore semDicoFileInfos = new System.Threading.Semaphore(1, 1);

    private Control ctrl;
    private Delegate deg;
    private cModuleConnection con;
    private int _instanceId;
    public asyncCallbackModuleEnumerate(ref Control ctr, Delegate de, ref cModuleConnection co, int iId)
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
        Dictionary<string, moduleInfos> dico = new Dictionary<string, moduleInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (moduleInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestModuleList, pObj.pid);
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
                    Dictionary<string, moduleInfos> _dico = new Dictionary<string, moduleInfos>();
                    string msg = "";
                    bool res = Wmi.Objects.Module.EnumerateModuleById(pObj.pid, con.wmiSearcher, ref _dico, ref msg);

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

                    Dictionary<string, moduleInfos> _dico = new Dictionary<string, moduleInfos>();
                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                        // For some processes only
                        _dico = snap.ModulesByProcessId(pObj.pid);
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
                    Dictionary<string, moduleInfos> _dico = SharedLocalSyncEnumerate(pObj);

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
    public static Dictionary<string, moduleInfos> SharedLocalSyncEnumerate(poolObj pObj)
    {
        Dictionary<string, moduleInfos> _dico;

        // If it's a Wow64 process, module enumeration is made using debug functions
        cProcess cProc = cProcess.GetProcessById(pObj.pid);
        if (cProc != null && cProc.IsWow64Process)
            _dico = Native.Objects.Module.EnumerateModulesWow64ByProcessId(pObj.pid, false);
        else
            // Normal native enumeration
            _dico = Native.Objects.Module.EnumerateModulesByProcessId(pObj.pid, false);

        return _dico;
    }
}

