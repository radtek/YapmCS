
public class asyncCallbackProcGetAllNonFixedInfos
{
    public event HasGotAllNonFixedInfosEventHandler HasGotAllNonFixedInfos;

    public delegate void HasGotAllNonFixedInfosEventHandler(bool Success, ref Native.Api.NativeStructs.SystemProcessInformation newInfos, string msg);

    private cProcessConnection _connection;
    private cProcess _process;

    public asyncCallbackProcGetAllNonFixedInfos(ref cProcessConnection procConnection, ref cProcess process)
    {
        _connection = procConnection;
        _process = process;
    }

    // This function is only called for WMI connexion
    // It is called when user want to refresh statistics of a process in detailed view
    public void Process(object state)
    {
        switch (_connection.ConnectionObj.ConnectionType)
        {
            case cConnection.TypeOfConnection.RemoteConnectionViaSocket:
                {
                    break;
                }

            case cConnection.TypeOfConnection.RemoteConnectionViaWMI:
                {
                    string msg = "";
                    Native.Api.NativeStructs.SystemProcessInformation _newInfos = new Native.Api.NativeStructs.SystemProcessInformation();
                    bool ret = Wmi.Objects.Process.RefreshProcessInformationsById(_process.Infos.ProcessId, _connection.wmiSearcher, ref msg, ref _newInfos);

                    HasGotAllNonFixedInfos?.Invoke(ret, ref _newInfos, msg);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
}

