// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// =======================================================


// YAPM is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// YAPM is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with YAPM; if not, see http://www.gnu.org/licenses/.


using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Common;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System;
using Microsoft.Samples;
using System.Net;
using System.Net.Sockets;
using Common.Misc;

public partial class frmServer
{
    frmServer()
    {
        sock = new AsynchronousSocketListener();
    }

    private AsynchronousSocketListener _sock;

    private AsynchronousSocketListener sock
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sock;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sock != null)
            {
                _sock.Connected -= sock_ConnexionAccepted;
                _sock.Disconnected -= sock_Disconnected;
                _sock.WaitingForConnection -= sock_Waiting;
                _sock.ReceivedData -= sock_ReceivedData;
            }

            _sock = value;
            if (_sock != null)
            {
                _sock.Connected += sock_ConnexionAccepted;
                _sock.Disconnected += sock_Disconnected;
                _sock.WaitingForConnection += sock_Waiting;
                _sock.ReceivedData += sock_ReceivedData;
            }
        }
    }

    private SOCK_STATE _state = SOCK_STATE.Disconnected;

    private enum SOCK_STATE : int
    {
        Connected,
        WaitingConnection,
        Disconnected
    }

    private cConnection theConnection = new cConnection();
    private cProcessConnection _procCon = new cProcessConnection(this, ref theConnection, ref new cProcessConnection.HasEnumeratedEventHandler(HasEnumeratedProcess));
    private cWindowConnection _windowCon = new cWindowConnection(this, ref theConnection, ref new cWindowConnection.HasEnumeratedEventHandler(HasEnumeratedWindows));
    private cEnvVariableConnection _envCon = new cEnvVariableConnection(this, ref theConnection, ref new cEnvVariableConnection.HasEnumeratedEventHandler(HasEnumeratedEnvVar));
    private cHandleConnection _handleCon = new cHandleConnection(this, ref theConnection, ref new cHandleConnection.HasEnumeratedEventHandler(HasEnumeratedHandle));
    private cMemRegionConnection _memoryCon = new cMemRegionConnection(this, ref theConnection, ref new cMemRegionConnection.HasEnumeratedEventHandler(HasEnumeratedMemoryReg));
    private cModuleConnection _moduleCon = new cModuleConnection(this, ref theConnection, ref new cModuleConnection.HasEnumeratedEventHandler(HasEnumeratedModule));
    private cNetworkConnection _networkCon = new cNetworkConnection(this, ref theConnection, ref new cNetworkConnection.HasEnumeratedEventHandler(HasEnumeratedNetwork));
    private cServiceConnection _serviceCon = new cServiceConnection(this, ref theConnection, ref new cServiceConnection.HasEnumeratedEventHandler(HasEnumeratedService));
    private cServDepConnection _servdepCon = new cServDepConnection(this, ref theConnection, ref new cServDepConnection.HasEnumeratedEventHandler(HasEnumeratedServDep));
    private cPrivilegeConnection _priviCon = new cPrivilegeConnection(this, ref theConnection, ref new cPrivilegeConnection.HasEnumeratedEventHandler(HasEnumeratedPrivilege));
    private cTaskConnection _taskCon = new cTaskConnection(this, ref theConnection, ref new cTaskConnection.HasEnumeratedEventHandler(HasEnumeratedTask));
    private cThreadConnection _threadCon = new cThreadConnection(this, ref theConnection, ref new cThreadConnection.HasEnumeratedEventHandler(HasEnumeratedThread));
    private cSearchConnection _searchCon = new cSearchConnection(this, ref theConnection, ref new cSearchConnection.HasEnumeratedEventHandler(HasEnumeratedSearch));
    private cLogConnection _logCon = new cLogConnection(this, ref theConnection, ref new cLogConnection.HasEnumeratedEventHandler(HasEnumeratedLog));
    private cJobConnection _jobCon = new cJobConnection(this, ref theConnection, ref new cJobConnection.HasEnumeratedEventHandler(HasEnumeratedJobs));
    private cJobConnection _procInJobCon = new cJobConnection(this, ref theConnection, ref new cJobConnection.HasEnumeratedProcInJobEventHandler(HasEnumeratedProcessInJob));
    private cJobLimitConnection _jobLimitsCon = new cJobLimitConnection(this, ref theConnection, ref new cJobLimitConnection.HasEnumeratedEventHandler(HasEnumeratedJobLimits));
    private cHeapConnection _heapCon = new cHeapConnection(this, ref theConnection, ref new cHeapConnection.HasEnumeratedEventHandler(HasEnumeratedHeaps));

    // Connect to local machine
    private void connectLocal()
    {

        // Set connection
        try
        {
            {
                var withBlock = theConnection;
                withBlock.ConnectionType = cConnection.TypeOfConnection.LocalConnection;
                withBlock.Connect();
            }

            _procCon.ConnectionObj = theConnection;
            _networkCon.ConnectionObj = theConnection;
            _serviceCon.ConnectionObj = theConnection;
            _windowCon.ConnectionObj = theConnection;
            _threadCon.ConnectionObj = theConnection;
            _envCon.ConnectionObj = theConnection;
            _handleCon.ConnectionObj = theConnection;
            _moduleCon.ConnectionObj = theConnection;
            _memoryCon.ConnectionObj = theConnection;
            _priviCon.ConnectionObj = theConnection;
            _taskCon.ConnectionObj = theConnection;
            _searchCon.ConnectionObj = theConnection;
            _servdepCon.ConnectionObj = theConnection;
            _logCon.ConnectionObj = theConnection;
            _heapCon.ConnectionObj = theConnection;

            _networkCon.Connect();
            _moduleCon.Connect();
            _searchCon.Connect();
            _serviceCon.Connect();
            _servdepCon.Connect();
            _envCon.Connect();
            _memoryCon.Connect();
            _taskCon.Connect();
            _priviCon.Connect();
            _windowCon.Connect();
            _threadCon.Connect();
            _handleCon.Connect();
            _procCon.Connect();
            _logCon.Connect();
            _heapCon.Connect();

            cWindow.Connection = _windowCon;
            cProcess.Connection = _procCon;
            cThread.Connection = _threadCon;
            cEnvVariable.Connection = _envCon;
            cHandle.Connection = _handleCon;
            cMemRegion.Connection = _memoryCon;
            cModule.Connection = _moduleCon;
            cNetwork.Connection = _networkCon;
            cService.Connection = _serviceCon;
            cPrivilege.Connection = _priviCon;
            cTask.Connection = _taskCon;
            cLogItem.Connection = _logCon;
            cJob.Connection = _jobCon;
            cJobLimit.Connection = _jobLimitsCon;
            cHeap.Connection = _heapCon;
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Unable to connect");
        }
    }


    private string _TheIdToSend = "";
    private void HasEnumeratedEnvVar(bool Success, Dictionary<string, envVariableInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestEnvironmentVariableList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetEnvVarList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate environnement variables");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate environnement variables");
    }

    private void HasEnumeratedHeaps(bool Success, Dictionary<string, heapInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestHeapList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetHeapList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate heap list");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate heap list");
    }

    private void HasEnumeratedJobLimits(bool Success, Dictionary<string, jobLimitInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestJobLimits);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetJobLimitsList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate job limits");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate job limits");
    }

    private void HasEnumeratedProcessInJob(bool Success, Dictionary<string, processInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestProcessesInJobList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetProcessList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate processes in job");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate processes in job");
    }

    private void HasEnumeratedJobs(bool Success, Dictionary<string, jobInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestJobList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetJobList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate jobs");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate jobs");
    }

    private void HasEnumeratedLog(bool Success, Dictionary<string, logItemInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestLogList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetLogList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate log items");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate log items");
    }

    private void HasEnumeratedServDep(bool Success, Dictionary<string, serviceInfos> Dico, string errorMessage, int instanceId, cServDepConnection.DependenciesToget type)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestServDepList, null, type);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetServiceList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate service dependencies");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate service dependencies");
    }

    private void HasEnumeratedMemoryReg(bool Success, Dictionary<string, memRegionInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestMemoryRegionList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetMemoryRegList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate memory regions");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate memory regions");
    }

    private void HasEnumeratedProcess(bool Success, Dictionary<string, processInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestProcessList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetProcessList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate processes");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate processes");
    }

    private void HasEnumeratedPrivilege(bool Success, Dictionary<string, privilegeInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestPrivilegesList);
                cDat.InstanceId = instanceId;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetPrivilegeList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate privileges");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate privileges");
    }

    private void HasEnumeratedService(bool Success, Dictionary<string, serviceInfos> Dico, string errorMessage, int forII)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestServiceList);
                cDat.InstanceId = forII;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetServiceList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate services");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate services");
    }

    private void HasEnumeratedThread(bool Success, Dictionary<string, threadInfos> Dico, string errorMessage, int forII)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestThreadList);
                cDat.InstanceId = forII;   // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetThreadList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate threads");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate threads");
    }

    private void HasEnumeratedModule(bool Success, Dictionary<string, moduleInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestModuleList);
                cDat.InstanceId = instanceId;  // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetModuleList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate modules");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate modules");
    }

    private void HasEnumeratedHandle(bool Success, Dictionary<string, handleInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestHandleList);
                cDat.InstanceId = instanceId;  // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetHandleList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate handles");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate handles");
    }

    private void HasEnumeratedNetwork(bool Success, Dictionary<string, networkInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestNetworkConnectionList);
                cDat.InstanceId = instanceId;  // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetNetworkList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate network connections");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate network connections");
    }

    private void HasEnumeratedSearch(bool Success, Dictionary<string, searchInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestSearchList);
                cDat.InstanceId = instanceId;  // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetSearchList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to search the string");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to search the string");
    }

    private void HasEnumeratedTask(bool Success, Dictionary<string, windowInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestTaskList);
                cDat.InstanceId = instanceId;  // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetWindowsList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate tasks");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate tasks");
    }

    private void HasEnumeratedWindows(bool Success, Dictionary<string, windowInfos> Dico, string errorMessage, int instanceId)
    {
        if (Success)
        {
            try
            {
                cSocketData cDat = new cSocketData(cSocketData.DataType.RequestedList, cSocketData.OrderType.RequestWindowList);
                cDat.InstanceId = instanceId;  // The instance which requested the list
                cDat._id = _TheIdToSend;
                cDat.SetWindowsList(Dico);
                sock.Send(cDat);
            }
            catch (Exception ex)
            {
                Misc.ShowError(ex, "Unable to enumerate windows");
            }
        }
        else
            // Send an error
            Misc.ShowError("Unable to enumerate windows");
    }

    private void frmServeur_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        // Try
        sock.Disconnect();
    }

    private delegate void ChangeConnectState(SOCK_STATE state);
    private void handlerChangeConnectState(SOCK_STATE state)
    {
    }
    private void sock_ConnexionAccepted()
    {
        _state = SOCK_STATE.Connected;
        ChangeConnectState h = new ChangeConnectState(handlerChangeConnectState);
        h.Invoke(SOCK_STATE.Connected);
    }
    private void sock_Disconnected()
    {
        _state = SOCK_STATE.Disconnected;
        ChangeConnectState h = new ChangeConnectState(handlerChangeConnectState);
        h.Invoke(SOCK_STATE.Disconnected);
    }
    private void sock_Waiting()
    {
        _state = SOCK_STATE.WaitingConnection;
        ChangeConnectState h = new ChangeConnectState(handlerChangeConnectState);
        h.Invoke(SOCK_STATE.WaitingConnection);
    }

    private void sock_ReceivedData(ref cSocketData cData)
    {
        try
        {
            bool ret = true;       // Return for the functions (orders)

            if (cData == null)
            {
                Trace.WriteLine("Serialization error");
                return;
            }

            int _forInstanceId = cData.InstanceId;
            string _idToSend = cData._id;
            _TheIdToSend = _idToSend;

            // Add item to history
            this.Invoke(new addItemHandler(addItem), cData);

            // Extract the type of information we have to send
            if (cData.Type == cSocketData.DataType.Order)
            {

                // ===== Request lists and informations
                switch (cData.Order)
                {
                    case cSocketData.OrderType.RequestProcessList:
                        {
                            _procCon.Enumerate(true, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestNetworkConnectionList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            bool all = System.Convert.ToBoolean(cData.Param2);
                            _networkCon.Enumerate(true, ref pid, all, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestJobList:
                        {
                            _jobCon.Enumerate(true, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestProcessesInJobList:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            _procInJobCon.EnumerateProcessesInJob(name, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestJobLimits:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            _jobLimitsCon.Enumerate(name, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestServiceList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            bool all = System.Convert.ToBoolean(cData.Param2);
                            _serviceCon.Enumerate(true, pid, true, all, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestModuleList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            _moduleCon.Enumerate(true, ref pid, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestThreadList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            _threadCon.Enumerate(true, ref pid, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestHandleList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            bool unn = System.Convert.ToBoolean(cData.Param2);
                            _handleCon.Enumerate(true, ref pid, unn, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestWindowList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            bool all = System.Convert.ToBoolean(cData.Param3);
                            bool unn = System.Convert.ToBoolean(cData.Param2);
                            _windowCon.Enumerate(true, ref pid, unn, all, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestTaskList:
                        {
                            _taskCon.Enumerate(true, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestSearchList:
                        {
                            string st = System.Convert.ToString(cData.Param1);
                            Native.Api.Enums.GeneralObjectType include = (Native.Api.Enums.GeneralObjectType)cData.Param2;
                            bool _case = System.Convert.ToBoolean(cData.Param3);
                            _searchCon.Enumerate(ref st, _case, include, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestPrivilegesList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            _priviCon.Enumerate(true, ref pid, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestEnvironmentVariableList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            IntPtr peb = (IntPtr)cData.Param2;
                            _envCon.Enumerate(true, ref pid, peb, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestMemoryRegionList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            _memoryCon.Enumerate(true, ref pid, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestServDepList:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            cServDepConnection.DependenciesToget type = (cServDepConnection.DependenciesToget)cData.Param2;
                            _servdepCon.Enumerate(name, type, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestProcessorCount:
                        {
                            int procCount = cSystemInfo.GetProcessorCount();
                            try
                            {
                                cSocketData cDat = new cSocketData(cSocketData.DataType.Order, cSocketData.OrderType.ReturnProcessorCount, procCount);
                                cDat._id = _idToSend;
                                sock.Send(cDat);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not request processor count");
                            }
                            return;
                        }

                    case cSocketData.OrderType.RequestLogList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            asyncCallbackLogEnumerate.LogItemType infos = (asyncCallbackLogEnumerate.LogItemType)cData.Param2;
                            _logCon.Enumerate(infos, ref pid, _forInstanceId);
                            return;
                        }

                    case cSocketData.OrderType.RequestHeapList:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            _heapCon.Enumerate(ref pid, _forInstanceId); // D'OH
                            return;
                        }
                }



                // ===== Process functions
                switch (cData.Order)
                {
                    case cSocketData.OrderType.ProcessCreateNew:
                        {
                            try
                            {
                                string s = System.Convert.ToString(cData.Param1);
                                int pid = Interaction.Shell(s, AppWinStyle.NormalFocus);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not create a new process");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessReanalize:
                        {
                            asyncCallbackProcEnumerate.ReanalizeLocalAfterSocket(ref (int[])cData.Param1);
                            break;
                        }

                    case cSocketData.OrderType.ProcessChangeAffinity:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            int aff = System.Convert.ToInt32(cData.Param2);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).SetAffinity(aff);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change process affinity");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessChangePriority:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            System.Diagnostics.ProcessPriorityClass level = (ProcessPriorityClass)cData.Param2;
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).SetPriority(level);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change process priority");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessDecreasePriority:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).DecreasePriority();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change process priority");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessIncreasePriority:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).IncreasePriority();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change process priority");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessKill:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).Kill();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not kill process");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessKillByMethod:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            Native.Api.Enums.KillMethod method = (Native.Api.Enums.KillMethod)cData.Param2;
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).KillByMethod(method);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not kill process by method");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessKillTree:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).KillProcessTree();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not kill process tree");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessReduceWorkingSet:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).EmptyWorkingSetSize();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not reduce process' working set size");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessResume:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).ResumeProcess();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not resume process");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ProcessSuspend:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            try
                            {
                                Native.Objects.Process.GetProcessById(pid).SuspendProcess();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not suspend process");
                            }

                            break;
                        }
                }



                // ===== Windows functions
                switch (cData.Order)
                {
                    case cSocketData.OrderType.WindowBringToFront:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            bool value = System.Convert.ToBoolean(cData.Param2);
                            (new cWindow(hWnd)).BringToFront(value);
                            break;
                        }

                    case cSocketData.OrderType.WindowClose:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).Close();
                            break;
                        }

                    case cSocketData.OrderType.WindowDisable:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            cWindow w = new cWindow(hWnd);
                            w.Enabled = false;
                            break;
                        }

                    case cSocketData.OrderType.WindowEnable:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            cWindow w = new cWindow(hWnd);
                            w.Enabled = true;
                            break;
                        }

                    case cSocketData.OrderType.WindowFlash:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).Flash();
                            break;
                        }

                    case cSocketData.OrderType.WindowHide:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).Hide();
                            break;
                        }

                    case cSocketData.OrderType.WindowMaximize:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).Maximize();
                            break;
                        }

                    case cSocketData.OrderType.WindowMinimize:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).Minimize();
                            break;
                        }

                    case cSocketData.OrderType.WindowSetAsActiveWindow:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).SetAsActiveWindow();
                            break;
                        }

                    case cSocketData.OrderType.WindowSetAsForegroundWindow:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).SetAsForegroundWindow();
                            break;
                        }

                    case cSocketData.OrderType.WindowSetCaption:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            string s = System.Convert.ToString(cData.Param2);
                            cWindow w = new cWindow(hWnd);
                            w.Caption = s;
                            break;
                        }

                    case cSocketData.OrderType.WindowSetOpacity:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            byte o = System.Convert.ToByte(cData.Param2);
                            cWindow w = new cWindow(hWnd);
                            w.Opacity = o;
                            break;
                        }

                    case cSocketData.OrderType.WindowSetPositions:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            Native.Api.NativeStructs.Rect r = (Native.Api.NativeStructs.Rect)cData.Param2;
                            (new cWindow(hWnd)).SetPositions(r);
                            break;
                        }

                    case cSocketData.OrderType.WindowShow:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).Show();
                            break;
                        }

                    case cSocketData.OrderType.WindowStopFlashing:
                        {
                            IntPtr hWnd = (IntPtr)cData.Param1;
                            (new cWindow(hWnd)).StopFlashing();
                            break;
                        }
                }



                // ===== Service functions
                switch (cData.Order)
                {
                    case cSocketData.OrderType.ServiceDelete:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            try
                            {
                                Native.Objects.Service.GetServiceByName(name).DeleteService();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not delete service");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ServicePause:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            try
                            {
                                Native.Objects.Service.GetServiceByName(name).PauseService();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not pause service");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ServiceChangeServiceStartType:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            Native.Api.NativeEnums.ServiceStartType type = (Native.Api.NativeEnums.ServiceStartType)cData.Param2;
                            try
                            {
                                Native.Objects.Service.GetServiceByName(name).SetServiceStartType(type);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change service start type");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ServiceResume:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            try
                            {
                                Native.Objects.Service.GetServiceByName(name).ResumeService();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not resume service");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ServiceStart:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            try
                            {
                                Native.Objects.Service.GetServiceByName(name).StartService();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not start service");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ServiceStop:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            try
                            {
                                Native.Objects.Service.GetServiceByName(name).StopService();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not stop service");
                            }

                            break;
                        }
                }



                // ===== Thread functions
                switch (cData.Order)
                {
                    case cSocketData.OrderType.ThreadDecreasePriority:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            int tid = System.Convert.ToInt32(cData.Param2);
                            try
                            {
                                Native.Api.NativeStructs.SystemThreadInformation sti = new Native.Api.NativeStructs.SystemThreadInformation();
                                sti.ClientId = new Native.Api.NativeStructs.ClientId(pid, tid);
                                (new cThread(ref new threadInfos(ref sti), true)).DecreasePriority();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change thread priority");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ThreadIncreasePriority:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            int tid = System.Convert.ToInt32(cData.Param2);
                            try
                            {
                                Native.Api.NativeStructs.SystemThreadInformation sti = new Native.Api.NativeStructs.SystemThreadInformation();
                                sti.ClientId = new Native.Api.NativeStructs.ClientId(pid, tid);
                                (new cThread(ref new threadInfos(ref sti), true)).IncreasePriority();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change thread priority");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ThreadResume:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            int tid = System.Convert.ToInt32(cData.Param2);
                            try
                            {
                                Native.Api.NativeStructs.SystemThreadInformation sti = new Native.Api.NativeStructs.SystemThreadInformation();
                                sti.ClientId = new Native.Api.NativeStructs.ClientId(pid, tid);
                                (new cThread(ref new threadInfos(ref sti), false)).ThreadResume();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not resume thread");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ThreadSetAffinity:
                        {
                            break;
                        }

                    case cSocketData.OrderType.ThreadSetPriority:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            int tid = System.Convert.ToInt32(cData.Param2);
                            int level = System.Convert.ToInt32(cData.Param3);
                            try
                            {
                                Native.Api.NativeStructs.SystemThreadInformation sti = new Native.Api.NativeStructs.SystemThreadInformation();
                                sti.ClientId = new Native.Api.NativeStructs.ClientId(pid, tid);
                                (new cThread(ref new threadInfos(sti), false)).SetPriority((ThreadPriorityLevel)level);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not set thread priority");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ThreadSuspend:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            int tid = System.Convert.ToInt32(cData.Param2);
                            try
                            {
                                Native.Api.NativeStructs.SystemThreadInformation sti = new Native.Api.NativeStructs.SystemThreadInformation();
                                sti.ClientId = new Native.Api.NativeStructs.ClientId(pid, tid);
                                (new cThread(ref new threadInfos(ref sti), false)).ThreadSuspend();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not suspend thread");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ThreadTerminate:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            int tid = System.Convert.ToInt32(cData.Param2);
                            try
                            {
                                Native.Api.NativeStructs.SystemThreadInformation sti = new Native.Api.NativeStructs.SystemThreadInformation();
                                sti.ClientId = new Native.Api.NativeStructs.ClientId(pid, tid);
                                (new cThread(ref new threadInfos(ref sti), false)).ThreadTerminate();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not terminate thread");
                            }

                            break;
                        }
                }



                // ===== Other functions
                switch (cData.Order)
                {
                    case cSocketData.OrderType.JobTerminate:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            try
                            {
                                cJob.SharedLRTerminateJob(name);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not terminate job");
                            }

                            break;
                        }

                    case cSocketData.OrderType.JobSetLimits:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            Native.Api.NativeStructs.JobObjectBasicUiRestrictions l1 = (Native.Api.NativeStructs.JobObjectBasicUiRestrictions)cData.Param2;
                            Native.Api.NativeStructs.JobObjectExtendedLimitInformation l2 = (Native.Api.NativeStructs.JobObjectExtendedLimitInformation)cData.Param3;
                            try
                            {
                                cJob.SharedLRSetLimits(name, l1, l2);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not set job limits");
                            }

                            break;
                        }

                    case cSocketData.OrderType.JobAddProcessToJob:
                        {
                            string name = System.Convert.ToString(cData.Param1);
                            int[] pid = (int[])cData.Param2;
                            try
                            {
                                cJob.SharedLRAddProcess(name, pid);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not add process to job");
                            }

                            break;
                        }

                    case cSocketData.OrderType.MemoryFree:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            IntPtr address = (IntPtr)cData.Param2;
                            IntPtr size = (IntPtr)cData.Param3;
                            Native.Api.NativeEnums.MemoryState type = (Native.Api.NativeEnums.MemoryState)cData.Param4;
                            try
                            {
                                cMemRegion.SharedLRFree(pid, address, size, type);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not free memory region");
                            }

                            break;
                        }

                    case cSocketData.OrderType.MemoryChangeProtectionType:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            IntPtr address = (IntPtr)cData.Param2;
                            IntPtr size = (IntPtr)cData.Param3;
                            Native.Api.NativeEnums.MemoryProtectionType type = (Native.Api.NativeEnums.MemoryProtectionType)cData.Param4;
                            try
                            {
                                cMemRegion.SharedLRChangeProtection(pid, address, size, type);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change memory region protection type");
                            }

                            break;
                        }

                    case cSocketData.OrderType.HandleClose:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            IntPtr handle = (IntPtr)cData.Param2;
                            try
                            {
                                cHandle.SharedLRCloseHandle(pid, handle);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not close handle");
                            }

                            break;
                        }

                    case cSocketData.OrderType.ModuleUnload:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            IntPtr address = (IntPtr)cData.Param2;
                            try
                            {
                                cProcess.SharedRLUnLoadModuleFromProcess(pid, address);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not unload module");
                            }

                            break;
                        }

                    case cSocketData.OrderType.PrivilegeChangeStatus:
                        {
                            int pid = System.Convert.ToInt32(cData.Param1);
                            string name = System.Convert.ToString(cData.Param2);
                            Native.Api.NativeEnums.SePrivilegeAttributes status = (Native.Api.NativeEnums.SePrivilegeAttributes)cData.Param3;
                            try
                            {
                                cPrivilege.LocalChangeStatus(pid, name, status);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not change privilege status");
                            }

                            break;
                        }

                    case cSocketData.OrderType.GeneralCommandHibernate:
                        {
                            bool force = System.Convert.ToBoolean(cData.Param1);
                            try
                            {
                                cSystem.Hibernate(force);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not hibernate system");
                            }

                            break;
                        }

                    case cSocketData.OrderType.GeneralCommandLock:
                        {
                            bool force = System.Convert.ToBoolean(cData.Param1);
                            try
                            {
                                cSystem.Lock();
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not lock system");
                            }

                            break;
                        }

                    case cSocketData.OrderType.GeneralCommandLogoff:
                        {
                            bool force = System.Convert.ToBoolean(cData.Param1);
                            try
                            {
                                cSystem.Logoff(force);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not logoff system");
                            }

                            break;
                        }

                    case cSocketData.OrderType.GeneralCommandPoweroff:
                        {
                            bool force = System.Convert.ToBoolean(cData.Param1);
                            try
                            {
                                cSystem.Poweroff(force);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not poweroff system");
                            }

                            break;
                        }

                    case cSocketData.OrderType.GeneralCommandRestart:
                        {
                            bool force = System.Convert.ToBoolean(cData.Param1);
                            try
                            {
                                cSystem.Restart(force);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not restart system");
                            }

                            break;
                        }

                    case cSocketData.OrderType.GeneralCommandShutdown:
                        {
                            bool force = System.Convert.ToBoolean(cData.Param1);
                            try
                            {
                                cSystem.Shutdown(force);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not shutdown system");
                            }

                            break;
                        }

                    case cSocketData.OrderType.GeneralCommandSleep:
                        {
                            bool force = System.Convert.ToBoolean(cData.Param1);
                            try
                            {
                                cSystem.Sleep(force);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not sleep system");
                            }

                            break;
                        }

                    case cSocketData.OrderType.TcpClose:
                        {
                            IPEndPoint local = (IPEndPoint)cData.Param1;
                            IPEndPoint remote = (IPEndPoint)cData.Param2;
                            try
                            {
                                cNetwork.LocalCloseTCP(local, remote);
                            }
                            catch (Exception ex)
                            {
                                Misc.ShowError(ex, "Could not close TCP connection");
                            }

                            break;
                        }
                }
            }
        }
        catch (Exception ex)
        {
            Misc.ShowError(ex, "Could not process client request");
        }
    }

    private void frmServeur_Load(System.Object sender, System.EventArgs e)
    {
        if (Program.Parameters.ModeHidden)
        {
            this.Left = Pref.LEFT_POSITION_HIDDEN;
            this.ShowInTaskbar = false;
        }

        Native.Functions.Misc.SetTheme(this.lvServer.Handle);

        Misc.SetToolTip(this.txtIp, "Available IP of this machine");

        // sock.ConnexionAccepted = New AsynchronousServer.ConnexionAcceptedEventHandle(AddressOf sock_ConnexionAccepted)
        // sock.Disconnected = New AsynchronousServer.DisconnectedEventHandler(AddressOf sock_Disconnected)
        // sock.SentData = New AsynchronousServer.SentDataEventHandler(AddressOf sock_SentData)

        connectLocal();

        string[] s = Misc.GetIpv4Ips();
        if ((s == null) || s.Length == 0)
            this.txtIp.Text = "Error while trying to retrieve local IP address.";
        else if (s.Length == 1)
            this.txtIp.Text = "You will have to configure YAPM with this IP : " + s[0];
        else
        {
            this.txtIp.Text = "You have more than one network card, so you will have to use one of these IP addresses to configure YAPM : " + Constants.vbNewLine;
            foreach (string x in s)
                this.txtIp.Text += x + Constants.vbNewLine;
            this.txtIp.Text = this.txtIp.Text.Substring(0, this.txtIp.Text.Length - 2);
        }

        // Connect 
        ConnectNow();
    }

    private delegate void addItemHandler(ref cSocketData dat);
    private void addItem(ref cSocketData dat)
    {
        ListViewItem it = new ListViewItem(DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString());
        it.SubItems.Add(dat.ToString());
        this.lvServer.Items.Add(it);
    }

    private void ConnectNow()
    {
        // Connect or disconnect the socket (server)
        System.Threading.WaitCallback t = new System.Threading.WaitCallback(conDegCallBack);
        System.Threading.ThreadPool.QueueUserWorkItem(t, null);
    }

    private void conDegCallBack(object obj)
    {
        // Try
        if (_state == SOCK_STATE.Disconnected)
            sock.Connect(Program.Parameters.RemotePort);
        else
            sock.Disconnect();
    }

    // Send an error message to the client
    public void SendErrorToClient(cError _ex)
    {
        try
        {
            cSocketData cDat = new cSocketData(cSocketData.DataType.ErrorOnServer, param1: new SerializableException(_ex));
            sock.Send(cDat);
        }
        catch (Exception ex)
        {
            // FAILED !!
            Misc.ShowDebugError(ex);
        }
    }
}

