using Common;
using System.Collections;
using System;
using System.Threading;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemotingServerClient;
using MsdnMag.Remoting;

public class AsynchronousClient
{
    public delegate void ReceivedDataEventHandler(ref cSocketData data);
    public delegate void SentDataEventHandler();
    public delegate void DisconnectedEventHandler();
    public delegate void ConnectedEventHandler();
    public delegate void SocketErrorHandler();

    public event ReceivedDataEventHandler ReceivedData;
    public event SentDataEventHandler SentData;
    public event DisconnectedEventHandler Disconnected;
    public event ConnectedEventHandler Connected;
    public event SocketErrorHandler SocketError;

    private string _uniqueClientKey = "cDat._id";
    private static Semaphore semQueue = new Semaphore(1, 1);


    private ServerTalk _ServerTalk = null;
    // this object lives on the server
    private CallbackSink _CallbackSink = null;
    // this object lives here on the client

    private struct poolObjConnect
    {
        public string ServerName;
        public string ClientIp;
        public int Port;
        public poolObjConnect(string aServer, int aPort, string aClient)
        {
            ServerName = aServer;
            Port = aPort;
            ClientIp = aClient;
        }
    }

    public void Connect(string serverName, int port, string clientIp)
    {
        ThreadPool.QueueUserWorkItem(pvtConnect, new poolObjConnect(serverName, port, clientIp));
    }

    public void Disconnect()
    {
        ServerTalk.ClientToServerQueue.Clear();
        _ServerTalk.SendMessageToServer(new CommsInfo("clientDisconnect"));
        Disconnected?.Invoke();
    }

    public void Send(cSocketData dat)
    {
        // Add the object to send into the list (queue)
        // semQueue.WaitOne()
        dat._id = _uniqueClientKey;
        ThreadPool.QueueUserWorkItem(pvtSend, (object)dat);
    }


    private void pvtConnect(object context)
    {
        try
        {
            poolObjConnect pObj = (poolObjConnect)context;
            // creates a client object that 'lives' here on the client.
            _CallbackSink = new CallbackSink();
            // hook into the event exposed on the Sink object so we can transfer a server 
            // message through to this class.
            _CallbackSink.OnHostToClient += CallbackSink_OnHostToClient;
            // Register a client channel so the server can communicate back - it needs a channel
            // opened for the callback to the CallbackSink object that is anchored on the client!
            TcpChannel channel = null;
            try
            {
                // Now we'll create a channel for each network card interface
                Hashtable ht = new Hashtable();
                ht["name"] = "ClientChannel";
                ht["port"] = pObj.Port + 3;
                ht["bindTo"] = pObj.ClientIp;

                // now create and register our custom TcpChannel 
                BinaryServerFormatterSinkProvider serverFormatter = new BinaryServerFormatterSinkProvider();
                serverFormatter.Next = new SecureServerChannelSinkProvider();
                serverFormatter.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                channel = new TcpChannel(ht, null, serverFormatter);
                ChannelServices.RegisterChannel(channel, false);
            }
            catch (Exception ex)
            {
                // Already exists (reconnection)
                Misc.ShowDebugError(ex);
            }
            // now create a transparent proxy to the server component
            object obj = Activator.GetObject(typeof(ServerTalk), "tcp://" + pObj.ServerName + ":" + pObj.Port.ToString() + "/TalkIsGood");
            // cast returned object
            _ServerTalk = (ServerTalk)obj;
            // Register ourselves to the server with a callback to the client sink.
            _ServerTalk.RegisterHostToClient("client", new delCommsInfo(_CallbackSink.HandleToClient()));
            Connected?.Invoke();
        }
        catch (Exception ex)
        {
            Disconnected?.Invoke();
        }
    }

    private void pvtSend(object dat)
    {
        // Convert the string data to byte data using ASCII encoding.
        byte[] byteData = cSerialization.GetSerializedObject((cSocketData)dat);

        try
        {
            _ServerTalk.SendMessageToServer(new CommsInfo(byteData));
            SentData?.Invoke();
        }
        catch (Exception ex)
        {
            Disconnected?.Invoke();
        }
    }

    private void CallbackSink_OnHostToClient(CommsInfo info)
    {
        // Received a message
        cSocketData cDat = cSerialization.DeserializeObject(info.Data);
        ReceivedData?.Invoke(ref cDat);
    }
}
