using System.Collections.Generic;
using System.Collections;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemotingServerClient;
using MsdnMag.Remoting;

public class AsynchronousSocketListener
{
    public delegate void ReceivedDataEventHandler(ref cSocketData data);
    public delegate void SentDataEventHandler();
    public delegate void DisconnectedEventHandler();
    public delegate void ConnectedEventHandler();
    public delegate void SocketErrorHandler();
    public delegate void WaitingForConnectionHandler();

    public event ReceivedDataEventHandler ReceivedData;
    public event SentDataEventHandler SentData;
    public event DisconnectedEventHandler Disconnected;
    public event ConnectedEventHandler Connected;
    public event WaitingForConnectionHandler WaitingForConnection;
    public event SocketErrorHandler SocketError;


    // Private listener As Socket
    private Dictionary<string, Socket> _dicoClient = new Dictionary<string, Socket>();
    public static ManualResetEvent allDone = new ManualResetEvent(false);


    public void Connect(int port)
    {
        ThreadPool.QueueUserWorkItem(pvtConnect, (object)port);
    } // Main


    private void pvtConnect(object context)
    {
        try
        {
            int port = System.Convert.ToInt32(context);
            // Register a server channel on the Server where we 
            // will listen for clients who wish to communicate
            RegisterChannel(port);
            // Register callbacks to the static properties on the ServerTalk object
            ServerTalk.NewUser = new delUserInfo(NewUser);
            ServerTalk.ClientToHost = new delCommsInfo(ClientToHost);
            Thread t = new Thread(new ThreadStart(CheckClientToServerQueue));
            t.Start();
        }
        catch (Exception ex)
        {
            Disconnected?.Invoke();
        }
    }

    // The method that will be called when a new User registers.
    private void NewUser(string UserID)
    {
    }
    // A loop invoked by a worker-thread which will monitor the static tread-safe ClientToServer 
    // Queue on the ServerTalk class and passes on any CommsInfo objects that are placed here.
    // If the variable _FormClosing turns true (when the form closes) it will stop the loop and
    // subsequently the life of the worker-thread.
    private bool _FormClosing = false;
    private void CheckClientToServerQueue()
    {
        while (!_FormClosing)
        {
            Thread.Sleep(50);
            // allow rest of the system to continue whilst waiting...
            if (ServerTalk.ClientToServerQueue.Count > 0)
            {
                CommsInfo message = (CommsInfo)ServerTalk.ClientToServerQueue.Dequeue();
                if (message.Message == "clientDisconnect")
                {
                    // Oh, the client has disconnected !
                    ServerTalk.ClientToServerQueue.Clear();
                    // Let's empty the dictionnary of current processes/services
                    Native.Objects.Process.ClearNewProcessesDico();
                    Native.Objects.Service.ClearNewServicesList();
                }
                else
                    ClientToHost(message);
            }
        }
    }
    // A helper method that will marshal a CommsInfo from the client to 
    // our UI thread.
    private void ClientToHost(CommsInfo Info)
    {
        // since it originated from a different thread we need to marshal this back to the current UI thread.
        cSocketData cDat = cSerialization.DeserializeObject(Info.Data);
        ReceivedData?.Invoke(ref cDat);
    }

    private void RegisterChannel(int port)
    {
        // Set the TypeFilterLevel to Full since callbacks require additional security 
        // requirements
        BinaryServerFormatterSinkProvider serverFormatter = new BinaryServerFormatterSinkProvider();
        serverFormatter.Next = new SecureServerChannelSinkProvider();
        serverFormatter.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

        // we have to change the name since we can't have two channels with the same name.
        Hashtable ht = new Hashtable();
        ht["name"] = "ServerChannel";
        ht["port"] = port;

        // now create and register our custom TcpChannel 
        TcpChannel channel = new TcpChannel(ht, null, serverFormatter);
        ChannelServices.RegisterChannel(channel, false);

        // register a WKO type in Singleton mode
        string identifier = "TalkIsGood";
        WellKnownObjectMode mode = WellKnownObjectMode.Singleton;

        WellKnownServiceTypeEntry entry = new WellKnownServiceTypeEntry(typeof(ServerTalk), identifier, mode);
        RemotingConfiguration.RegisterWellKnownServiceType(entry);
    }

    public void Disconnect()
    {
        _FormClosing = true;
    }

    public void Send(cSocketData dat)
    {
        ThreadPool.QueueUserWorkItem(pvtSend, (object)dat);
    }

    private void pvtSend(object dat)
    {
        // Convert the string data to byte data using ASCII encoding.
        byte[] byteData = cSerialization.GetSerializedObject((cSocketData)dat);

        try
        {
            ServerTalk.RaiseHostToClient("*", byteData);
            SentData?.Invoke();
        }
        catch (Exception ex)
        {
            Disconnected?.Invoke();
        }
    }
}
