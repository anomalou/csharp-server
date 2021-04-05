using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Server.Core {
    class ServerEntity {

        #region Singleton

        private static ServerEntity INSTANCE;
        private static readonly object padlock = new object();

        public static ServerEntity Instance {
            get {
                lock (padlock) {
                    if (INSTANCE == null)
                        INSTANCE = new ServerEntity();
                    return INSTANCE;
                }
            }
        }

        #endregion


        public static ManualResetEvent tcpClientConnected = new ManualResetEvent(false);
        private ConnectionService connectionService;
        private bool _isRunning;

        private TcpListener listener;

        public bool isRunning {
            get {
                return _isRunning;
            }
            set {
                _isRunning = value;
            }
        }

        private ServerEntity () {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1337);
            connectionService = ConnectionService.Instance;
            //isRunning = false;
        }

        public void Stop () {
            //isRunning = false;
            //listener.EndAcceptTcpClient();

            listener.Stop();

            //TODO: Save DAO
        }

        public void Run () {
            // isRunning = true;
            //TODO: Get network data from property file

            listener.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(CreateConnection), listener);

            //TcpClient tcpClient = listener.AcceptTcpClient();
            //Connection connection = new Connection(tcpClient);
            //connectionService.AddConnection(connection);
        }

        private void CreateConnection (IAsyncResult asyncResult) {
            try {
                TcpListener listener = (TcpListener) asyncResult.AsyncState;

                TcpClient client = listener.EndAcceptTcpClient(asyncResult);
                Connection connection = new Connection(client);
                connectionService.AddConnection(connection);

                listener.BeginAcceptTcpClient(new AsyncCallback(CreateConnection), listener);
            }catch(Exception ex) {
                
            }
        }
    }
}
