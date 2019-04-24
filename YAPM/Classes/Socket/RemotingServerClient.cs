using System.Collections.Generic;
using System.Collections;
using System;
using System.Runtime.Remoting.Messaging;

namespace RemotingServerClient
{
    public delegate void delUserInfo(string UserID);
    public delegate void delCommsInfo(CommsInfo info);

    // This class is created on the server and allows for client to register their existance and
    // a call-back that the server can use to communicate back.
    public class ServerTalk : MarshalByRefObject
    {
        private static delUserInfo _NewUser;
        private static delCommsInfo _ClientToHost;
        private static List<ClientWrap> _list = new List<ClientWrap>();

        // Unlimited lifetime
        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void RegisterHostToClient(string UserID, delCommsInfo htc)
        {
            _list.Add(new ClientWrap(UserID, htc));
            _NewUser(UserID);
        }

        /// <summary>
        /// The host should register a function pointer to which it wants a signal
        /// send when a User Registers
        /// </summary>
        public static delUserInfo NewUser
        {
            get
            {
                return _NewUser;
            }
            set
            {
                _NewUser = value;
            }
        }

        /// <summary>
        /// The host should register a function pointer to which it wants the CommsInfo object
        /// send when the client wants to communicate to the server
        /// </summary>
        public static delCommsInfo ClientToHost
        {
            get
            {
                return _ClientToHost;
            }
            set
            {
                _ClientToHost = value;
            }
        }

        // the static method that will be invoked by the server when it wants to send a message
        // to a specific user or all of them.
        public static void RaiseHostToClient(string UserID, string Message)
        {
            foreach (ClientWrap client in _list)
            {
                if ((client.UserID == UserID || UserID == "*") && client.HostToClient != null)
                {
                    delCommsInfo D = client.HostToClient;
                    D(new CommsInfo(Message));
                }
            }
        }
        public static void RaiseHostToClient(string UserID, byte[] data)
        {
            foreach (ClientWrap client in _list)
            {
                if ((client.UserID == UserID || UserID == "*") && client.HostToClient != null)
                {
                    delCommsInfo D = client.HostToClient;
                    D(new CommsInfo(data));
                }
            }
        }

        // a thread-safe queue that will contain any message objects that should
        // be send to the server
        private static Queue _ClientToServer = Queue.Synchronized(new Queue());

        // this instance method allows a client to send a message to the server
        public void SendMessageToServer(CommsInfo Message)
        {
            _ClientToServer.Enqueue(Message);
        }

        public static Queue ClientToServerQueue
        {
            get
            {
                return _ClientToServer;
            }
        }

        // small private class to wrap the User and the callback together.
        private class ClientWrap
        {
            private string _UserID = "";
            private delCommsInfo _HostToClient = null;

            public ClientWrap(string UserID, delCommsInfo HostToClient)
            {
                _UserID = UserID;
                _HostToClient = HostToClient;
            }

            public string UserID
            {
                get
                {
                    return _UserID;
                }
            }

            public delCommsInfo HostToClient
            {
                get
                {
                    return _HostToClient;
                }
            }
        }
    }

    [Serializable()]
    public class CommsInfo
    {
        private string _Message = "";
        private byte[] _Data;

        public CommsInfo(string Message)
        {
            _Message = Message;
        }
        public CommsInfo(byte[] data)
        {
            _Data = data;
        }

        public byte[] Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
            }
        }
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
    }

    /// <summary>
    /// This CallbackSink object will be 'anchored' on the client and is used as the target for a callback
    /// given to the server.
    /// </summary>
    public class CallbackSink : MarshalByRefObject
    {
        public event delCommsInfo OnHostToClient;

        public CallbackSink()
        {
        }

        [OneWay()]
        public void HandleToClient(CommsInfo info)
        {
            OnHostToClient?.Invoke(info);
        }
    }
}
