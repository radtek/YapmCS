using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackSearchEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cSearchConnection con;
    private int _instanceId;
    public asyncCallbackSearchEnumerate(ref Control ctr, Delegate de, ref cSearchConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public string strSearch;
        public bool caseSen;
        public Native.Api.Enums.GeneralObjectType includ;
        public int forInstanceId;
        public poolObj(ref string strToSearch, bool @case, Native.Api.Enums.GeneralObjectType include, int ii)
        {
            strSearch = strToSearch;
            caseSen = @case;
            includ = include;
            forInstanceId = ii;
        }
    }

    // When socket got a list  !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys)
    {
        Dictionary<string, searchInfos> dico = new Dictionary<string, searchInfos>();
        if (lst != null && keys != null && lst.Length == keys.Length)
        {
            var loopTo = lst.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                dico.Add(keys[x], (searchInfos)lst[x]);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestSearchList, pObj.strSearch, pObj.includ, pObj.caseSen);
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

                    Dictionary<string, searchInfos> _dico = new Dictionary<string, searchInfos>();
                    int key = 0;

                    string sToSearch = pObj.strSearch;
                    if (pObj.caseSen == false)
                        sToSearch = sToSearch.ToLowerInvariant();

                    cSnapshot snap = con.ConnectionObj.Snapshot;
                    if (snap != null)
                    {

                        // ---- PROCESSES
                        Dictionary<string, processInfos> _procs = new Dictionary<string, processInfos>();
                        _procs = snap.Processes;
                        if (snap.Processes != null)
                        {
                            if (_procs != null)
                            {
                                foreach (processInfos proc in _procs.Values)
                                {
                                    cProcess cp = new cProcess(ref proc);
                                    foreach (string field in processInfos.GetAvailableProperties())
                                    {
                                        string scomp = cp.GetInformation(field);
                                        if (scomp != null)
                                        {
                                            if (pObj.caseSen == false)
                                                scomp = scomp.ToLowerInvariant();
                                            if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                            {
                                                // Found an item
                                                searchInfos newItFound = new searchInfos(cp, field, scomp);
                                                key += 1;
                                                _dico.Add(key.ToString(), newItFound);
                                            }
                                        }
                                    }

                                    // ---- MODULES
                                    if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Module) == Native.Api.Enums.GeneralObjectType.Module)
                                    {
                                        Dictionary<string, moduleInfos> _tmpDico2 = new Dictionary<string, moduleInfos>();
                                        _tmpDico2 = snap.ModulesByProcessId(cp.Infos.ProcessId);
                                        if (_tmpDico2 != null)
                                        {
                                            foreach (moduleInfos cm in _tmpDico2.Values)
                                            {
                                                cModule cmm = new cModule(ref cm);
                                                foreach (string field2 in processInfos.GetAvailableProperties())
                                                {
                                                    string scomp2 = cmm.GetInformation(field2);
                                                    if (scomp2 != null)
                                                    {
                                                        if (pObj.caseSen == false)
                                                            scomp2 = scomp2.ToLowerInvariant();
                                                        if (Strings.InStr(scomp2, sToSearch, CompareMethod.Binary) > 0)
                                                        {
                                                            // Found an item
                                                            searchInfos newItFound = new searchInfos(cmm, field2, scomp2);
                                                            key += 1;
                                                            _dico.Add(key.ToString(), newItFound);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    // ---- ENVVARIABLES
                                    if ((pObj.includ & Native.Api.Enums.GeneralObjectType.EnvironmentVariable) == Native.Api.Enums.GeneralObjectType.EnvironmentVariable)
                                    {
                                        Dictionary<string, envVariableInfos> _tmpDico2 = new Dictionary<string, envVariableInfos>();
                                        _tmpDico2 = snap.EnvironnementVariablesByProcessId(proc.ProcessId);
                                        if (_tmpDico2 != null)
                                        {
                                            foreach (envVariableInfos cm in _tmpDico2.Values)
                                            {
                                                cEnvVariable cmm = new cEnvVariable(ref cm);
                                                foreach (string field2 in envVariableInfos.GetAvailableProperties())
                                                {
                                                    string scomp2 = cmm.GetInformation(field2);
                                                    if (scomp2 != null)
                                                    {
                                                        if (pObj.caseSen == false)
                                                            scomp2 = scomp2.ToLowerInvariant();
                                                        if (Strings.InStr(scomp2, sToSearch, CompareMethod.Binary) > 0)
                                                        {
                                                            // Found an item
                                                            searchInfos newItFound = new searchInfos(cmm, field2, scomp2);
                                                            key += 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // ---- SERVICES
                        if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Service) == Native.Api.Enums.GeneralObjectType.Service)
                        {
                            Dictionary<string, serviceInfos> _tmpDico = new Dictionary<string, serviceInfos>();
                            _tmpDico = snap.Services;
                            if (_tmpDico != null)
                            {
                                foreach (serviceInfos cp in _tmpDico.Values)
                                {
                                    cService cpp = new cService(ref cp);
                                    foreach (string field in serviceInfos.GetAvailableProperties())
                                    {
                                        string scomp = cpp.GetInformation(field);
                                        if (scomp != null)
                                        {
                                            if (pObj.caseSen == false)
                                                scomp = scomp.ToLowerInvariant();
                                            if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                            {
                                                // Found an item
                                                searchInfos newItFound = new searchInfos(cpp, field, scomp);
                                                key += 1;
                                                _dico.Add(key.ToString(), newItFound);
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        // ---- HANDLES
                        if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Handle) == Native.Api.Enums.GeneralObjectType.Handle)
                        {
                            if (_procs != null)
                            {
                                foreach (processInfos theproc in _procs.Values)
                                {
                                    Dictionary<string, handleInfos> _tmpDico = new Dictionary<string, handleInfos>();
                                    _tmpDico = snap.HandlesByProcessId(theproc.ProcessId);
                                    foreach (handleInfos cp in _tmpDico.Values)
                                    {
                                        cHandle cpp = new cHandle(ref cp);
                                        foreach (string field in handleInfos.GetAvailableProperties())
                                        {
                                            string scomp = cpp.GetInformation(field);
                                            if (scomp != null)
                                            {
                                                if (pObj.caseSen == false)
                                                    scomp = scomp.ToLowerInvariant();
                                                if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                                {
                                                    // Found an item
                                                    searchInfos newItFound = new searchInfos(cpp, field, scomp);
                                                    key += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        // ---- WINDOWS
                        if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Window) == Native.Api.Enums.GeneralObjectType.Window)
                        {
                            if (_procs != null)
                            {
                                foreach (processInfos theproc in _procs.Values)
                                {
                                    Dictionary<string, windowInfos> _tmpDico = new Dictionary<string, windowInfos>();
                                    _tmpDico = snap.WindowsByProcessId(theproc.ProcessId);
                                    foreach (windowInfos cp in _tmpDico.Values)
                                    {
                                        cWindow cpp = new cWindow(ref cp);
                                        foreach (string field in windowInfos.GetAvailableProperties())
                                        {
                                            string scomp = cpp.GetInformation(field);
                                            if (scomp != null)
                                            {
                                                if (pObj.caseSen == false)
                                                    scomp = scomp.ToLowerInvariant();
                                                if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                                {
                                                    // Found an item
                                                    searchInfos newItFound = new searchInfos(cpp, field, scomp);
                                                    key += 1;
                                                    _dico.Add(key.ToString(), newItFound);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
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

            default:
                {
                    // Local

                    Dictionary<string, searchInfos> _dico = new Dictionary<string, searchInfos>();
                    int key = 0;

                    string sToSearch = pObj.strSearch;
                    if (pObj.caseSen == false)
                        sToSearch = sToSearch.ToLowerInvariant();

                    // ---- PROCESSES
                    if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Process) == Native.Api.Enums.GeneralObjectType.Process)
                    {
                        Native.Objects.Process.SemCurrentProcesses.WaitOne();
                        if (Native.Objects.Process.CurrentProcesses != null)
                        {
                            Dictionary<string, cProcess> _tmpDico = new Dictionary<string, cProcess>();
                            _tmpDico = Native.Objects.Process.CurrentProcesses;
                            foreach (cProcess cp in _tmpDico.Values)
                            {
                                foreach (string field in processInfos.GetAvailableProperties())
                                {
                                    string scomp = cp.GetInformation(field);
                                    if (scomp != null)
                                    {
                                        if (pObj.caseSen == false)
                                            scomp = scomp.ToLowerInvariant();
                                        if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                        {
                                            // Found an item
                                            searchInfos newItFound = new searchInfos(cp, field, scomp);
                                            key += 1;
                                            _dico.Add(key.ToString(), newItFound);
                                        }
                                    }
                                }

                                // ---- MODULES
                                if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Module) == Native.Api.Enums.GeneralObjectType.Module)
                                {
                                    Dictionary<string, cModule> _tmpDico2 = cModule.CurrentLocalModules(cp.Infos.ProcessId);
                                    foreach (cModule cm in _tmpDico2.Values)
                                    {
                                        foreach (string field2 in processInfos.GetAvailableProperties())
                                        {
                                            string scomp2 = cm.GetInformation(field2);
                                            if (scomp2 != null)
                                            {
                                                if (pObj.caseSen == false)
                                                    scomp2 = scomp2.ToLowerInvariant();
                                                if (Strings.InStr(scomp2, sToSearch, CompareMethod.Binary) > 0)
                                                {
                                                    // Found an item
                                                    searchInfos newItFound = new searchInfos(cm, field2, scomp2);
                                                    key += 1;
                                                    _dico.Add(key.ToString(), newItFound);
                                                }
                                            }
                                        }
                                    }
                                }

                                // ---- ENVVARIABLES
                                if ((pObj.includ & Native.Api.Enums.GeneralObjectType.EnvironmentVariable) == Native.Api.Enums.GeneralObjectType.EnvironmentVariable)
                                {
                                    Dictionary<string, cEnvVariable> _tmpDico2 = cEnvVariable.CurrentEnvVariables(cp);
                                    foreach (cEnvVariable cm in _tmpDico2.Values)
                                    {
                                        foreach (string field2 in envVariableInfos.GetAvailableProperties())
                                        {
                                            string scomp2 = cm.GetInformation(field2);
                                            if (scomp2 != null)
                                            {
                                                if (pObj.caseSen == false)
                                                    scomp2 = scomp2.ToLowerInvariant();
                                                if (Strings.InStr(scomp2, sToSearch, CompareMethod.Binary) > 0)
                                                {
                                                    // Found an item
                                                    searchInfos newItFound = new searchInfos(cm, field2, scomp2);
                                                    key += 1;
                                                    _dico.Add(key.ToString(), newItFound);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Native.Objects.Process.SemCurrentProcesses.Release();
                    }

                    // ---- SERVICES
                    if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Service) == Native.Api.Enums.GeneralObjectType.Service)
                    {
                        Native.Objects.Service.SemCurrentServices.WaitOne();
                        if (Native.Objects.Service.CurrentServices != null)
                        {
                            Dictionary<string, cService> _tmpDico = new Dictionary<string, cService>();
                            _tmpDico = Native.Objects.Service.CurrentServices;
                            foreach (cService cp in _tmpDico.Values)
                            {
                                foreach (string field in serviceInfos.GetAvailableProperties())
                                {
                                    string scomp = cp.GetInformation(field);
                                    if (scomp != null)
                                    {
                                        if (pObj.caseSen == false)
                                            scomp = scomp.ToLowerInvariant();
                                        if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                        {
                                            // Found an item
                                            searchInfos newItFound = new searchInfos(cp, field, scomp);
                                            key += 1;
                                            _dico.Add(key.ToString(), newItFound);
                                        }
                                    }
                                }
                            }
                        }
                        Native.Objects.Service.SemCurrentServices.Release();
                    }


                    // ---- HANDLES
                    if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Handle) == Native.Api.Enums.GeneralObjectType.Handle)
                    {
                        Dictionary<string, cHandle> _tmpDico = new Dictionary<string, cHandle>();
                        _tmpDico = Native.Objects.Handle.EnumerateCurrentLocalHandles();
                        foreach (cHandle cp in _tmpDico.Values)
                        {
                            foreach (string field in handleInfos.GetAvailableProperties())
                            {
                                string scomp = cp.GetInformation(field);
                                if (scomp != null)
                                {
                                    if (pObj.caseSen == false)
                                        scomp = scomp.ToLowerInvariant();
                                    if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                    {
                                        // Found an item
                                        searchInfos newItFound = new searchInfos(cp, field, scomp);
                                        key += 1;
                                        _dico.Add(key.ToString(), newItFound);
                                    }
                                }
                            }
                        }
                    }


                    // ---- WINDOWS
                    if ((pObj.includ & Native.Api.Enums.GeneralObjectType.Window) == Native.Api.Enums.GeneralObjectType.Window)
                    {
                        Dictionary<string, cWindow> _tmpDico = new Dictionary<string, cWindow>();
                        _tmpDico = Native.Objects.Window.EnumerateAllWindows();
                        foreach (cWindow cp in _tmpDico.Values)
                        {
                            foreach (string field in windowInfos.GetAvailableProperties())
                            {
                                string scomp = cp.GetInformation(field);
                                if (scomp != null)
                                {
                                    if (pObj.caseSen == false)
                                        scomp = scomp.ToLowerInvariant();
                                    if (Strings.InStr(scomp, sToSearch, CompareMethod.Binary) > 0)
                                    {
                                        // Found an item
                                        searchInfos newItFound = new searchInfos(cp, field, scomp);
                                        key += 1;
                                        _dico.Add(key.ToString(), newItFound);
                                    }
                                }
                            }
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

        sem.Release();
    }
}
