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
using System.Runtime.InteropServices;
using Common.Misc;

public partial class frmHandleInfo
{
    private cHandle _curHandle;

    private cHandle curHandle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _curHandle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_curHandle != null)
            {
            }

            _curHandle = value;
            if (_curHandle != null)
            {
            }
        }
    }

    private cConnection _theConnection;

    private cConnection theConnection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _theConnection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_theConnection != null)
            {
            }

            _theConnection = value;
            if (_theConnection != null)
            {
            }
        }
    }

    private bool _local = true;
    private bool _notWMI;
    private bool _notSnapshotMode = true;

    // Detailed informations' usercontrol
    private HXXXProp _ctrlDetails;


    // Refresh current tab
    private void refreshServiceTab()
    {
        if (curHandle == null)
            return;

        switch (this.tabProcess.SelectedTab.Text)
        {
            case "Details":
                {
                    this.txtAccess.Text = curHandle.GetInformation("GrantedAccess");
                    this.txtAddress.Text = curHandle.GetInformation("ObjectAddress");
                    this.txtName.Text = curHandle.GetInformation("Name");
                    this.txtType.Text = curHandle.GetInformation("Type");
                    this.lblHandleCount.Text = curHandle.GetInformation("HandleCount");
                    this.lblNonPaged.Text = curHandle.GetInformation("NonPagedPoolUsage");
                    this.lblPaged.Text = curHandle.GetInformation("PagedPoolUsage");
                    this.lblObjectCount.Text = curHandle.GetInformation("ObjectCount");
                    this.lblPointerCount.Text = curHandle.GetInformation("PointerCount");

                    // Refresh infos on the custom usercontrol
                    if (_ctrlDetails != null)
                        _ctrlDetails.RefreshInfos();
                    else
                        this.gpCustomControl.Enabled = false;
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    private void frmServiceInfo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5)
            refreshServiceTab();
    }

    private void frmProcessInfo_Load(object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        // Some tooltips


        Connect();
        refreshServiceTab();
    }

    // Get process to monitor
    public void SetHandle(ref cHandle handle)
    {
        curHandle = handle;

        this.Text = "Handle " + curHandle.Infos.Handle.ToString();

        _local = (cHandle.Connection.ConnectionObj.ConnectionType == cConnection.TypeOfConnection.LocalConnection);
        _notWMI = (cHandle.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.RemoteConnectionViaWMI);
        _notSnapshotMode = (cHandle.Connection.ConnectionObj.ConnectionType != cConnection.TypeOfConnection.SnapshotFile);

        // Add a custom usercontrol to our form depending of the handle type
        switch (handle.Infos.Type)
        {
            case "Adapter":
                {
                    break;
                }

            case "AlpcPort":
                {
                    break;
                }

            case "Callback":
                {
                    break;
                }

            case "Controller":
                {
                    break;
                }

            case "DebugObject":
                {
                    break;
                }

            case "Desktop":
                {
                    break;
                }

            case "Device":
                {
                    break;
                }

            case "Directory":
                {
                    break;
                }

            case "Driver":
                {
                    break;
                }

            case "EtwRegistration":
                {
                    break;
                }

            case "Event":
                {
                    break;
                }

            case "EventPair":
                {
                    break;
                }

            case "File":
                {
                    _ctrlDetails = new HFileProp(curHandle);
                    break;
                }

            case "FilterCommunicationPort":
                {
                    break;
                }

            case "FilterConnectionPort":
                {
                    break;
                }

            case "IoCompletion":
                {
                    break;
                }

            case "Job":
                {
                    _ctrlDetails = new HJobProp(curHandle);
                    break;
                }

            case "Key":
                {
                    _ctrlDetails = new HKeyProp(curHandle);
                    break;
                }

            case "KeyedEvent":
                {
                    break;
                }

            case "Mutant":
                {
                    break;
                }

            case "Process":
                {
                    _ctrlDetails = new HProcessProp(curHandle);
                    break;
                }

            case "Profile":
                {
                    break;
                }

            case "Section":
                {
                    break;
                }

            case "Semaphore":
                {
                    break;
                }

            case "Session":
                {
                    break;
                }

            case "SymbolicLink":
                {
                    break;
                }

            case "Thread":
                {
                    _ctrlDetails = new HThreadProp(curHandle);
                    break;
                }

            case "Timer":
                {
                    break;
                }

            case "TmEn":
                {
                    break;
                }

            case "TmRm":
                {
                    break;
                }

            case "TmTm":
                {
                    break;
                }

            case "TmTx":
                {
                    break;
                }

            case "Token":
                {
                    break;
                }

            case "TpWorkerFactory":
                {
                    break;
                }

            case "Type":
                {
                    break;
                }

            case "WindowStation":
                {
                    break;
                }

            case "WmiGuid":
                {
                    break;
                }
        }

        if (_ctrlDetails != null)
        {
            this.gpCustomControl.Controls.Add(_ctrlDetails);
            _ctrlDetails.Dock = DockStyle.Fill;
        }
    }

    // Connection
    public void Connect()
    {
    }
}
