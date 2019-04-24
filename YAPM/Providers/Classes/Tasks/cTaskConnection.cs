using System.Diagnostics;
using System.Windows.Forms;

public class cTaskConnection : cWindowConnection
{
    private int _instanceId = 1;
    private asyncCallbackTaskEnumerate _taskEnum;

    public cTaskConnection(Control ControlWhichGetInvoked, ref cConnection Conn, ref HasEnumeratedEventHandler de) : base(ControlWhichGetInvoked, ref Conn, ref de)
    {
        instanceId += 1;
        _instanceId = instanceId;
        _taskEnum = new asyncCallbackTaskEnumerate(ref _control, de, ref this, _instanceId);
    }


    // Enumerate threads
    public new int Enumerate(bool getFixedInfos, int forInstanceId = -1)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(_taskEnum.Process()), new asyncCallbackTaskEnumerate.poolObj(forInstanceId));
    }



    protected override void _sock_Connected()
    {
        _connected = true;
    }

    protected override void _sock_Disconnected()
    {
        _connected = false;
    }

    protected new void _sock_ReceivedData(ref cSocketData data)
    {

        // Exit immediately if not connected
        if (Program.Connection.IsConnected == false || Program.Connection.ConnectionType != cConnection.TypeOfConnection.RemoteConnectionViaSocket)
            return;

        if (data == null)
        {
            Trace.WriteLine("Serialization error");
            return;
        }

        if (data.Type == cSocketData.DataType.RequestedList && data.Order == cSocketData.OrderType.RequestTaskList)
        {
            if (_instanceId == data.InstanceId)
                // OK it is for me
                _taskEnum.GotListFromSocket(ref data.GetList, ref data.GetKeys);
        }
    }

    protected override void _sock_SentData()
    {
    }
}

