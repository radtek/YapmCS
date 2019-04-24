using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System;

public class asyncCallbackServDepEnumerate
{
    private Control ctrl;
    private Delegate deg;
    private cServDepConnection con;
    private int _instanceId;

    public asyncCallbackServDepEnumerate(ref Control ctr, Delegate de, ref cServDepConnection co, int iId)
    {
        ctrl = ctr;
        deg = de;
        _instanceId = iId;
        con = co;
    }

    public struct poolObj
    {
        public string name;
        public cServDepConnection.DependenciesToget type;
        public int forInstanceId;
        public poolObj(string nam, cServDepConnection.DependenciesToget typ, int forII)
        {
            name = nam;
            type = typ;
            forInstanceId = forII;
        }
    }


    // When socket got a list !
    private poolObj _poolObj;
    internal void GotListFromSocket(ref generalInfos[] lst, ref string[] keys, cServDepConnection.DependenciesToget type)
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
                ctrl.Invoke(deg, true, dico, null, _instanceId, type);
        }
        catch (Exception ex)
        {
        }
    }
    internal static System.Threading.Semaphore sem = new System.Threading.Semaphore(1, 1);
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
                        cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.RequestServDepList, pObj.name, pObj.type);
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
                    break;
                }

            default:
                {
                    // Local
                    Dictionary<string, serviceInfos> _dico = new Dictionary<string, serviceInfos>();
                    if (pObj.type == cServDepConnection.DependenciesToget.ServiceWhichDependsFromMe)
                        recursiveAddDep(pObj.name, pObj.name, ref _dico);
                    else
                        recursiveAddDep2(pObj.name, pObj.name, ref _dico);
                    try
                    {
                        if (deg != null && ctrl.Created)
                            ctrl.Invoke(deg, true, _dico, Native.Api.Win32.GetLastError(), pObj.forInstanceId, pObj.type);
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

    private void recursiveAddDep(string parent, string chain, ref Dictionary<string, serviceInfos> _dico)
    {
        foreach (serviceInfos ii in Native.Objects.Service.GetServiceDependencies(parent).Values)
        {
            ii.Tag = false;
            _dico.Add(chain + "->" + ii.Name, ii);
            recursiveAddDep(ii.Name, chain + "->" + ii.Name, ref _dico);
        }
    }
    private void recursiveAddDep2(string parent, string chain, ref Dictionary<string, serviceInfos> _dico)
    {
        foreach (serviceInfos ii in Native.Objects.Service.GetServiceWhichDependFromByServiceName(parent).Values)
        {
            ii.Tag = false;
            _dico.Add(chain + "->" + ii.Name, ii);
            recursiveAddDep2(ii.Name, chain + "->" + ii.Name, ref _dico);
        }
    }
}

