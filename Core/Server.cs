using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace Server.Core {
    //TODO: rename to ServerEntity 
    class Server {

        #region Singleton

        private static Server INSTANCE;
        private static readonly object padlock = new object();

        public static Server Instance {
            get {
                lock (padlock) {
                    if (INSTANCE == null)
                        INSTANCE = new Server();
                    return INSTANCE;
                }
            }
        }

        #endregion

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

        private Server () {
            connectionService = ConnectionService.Instance;
            isRunning = false;
        }

        public void Run () {
            // isRunning = true;
            //TODO: Get network data from property file

            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1337);

            listener.Start();
            while (isRunning) {
                TcpClient tcpClient = listener.AcceptTcpClient();
                Connection connection = new Connection(tcpClient);
                connectionService.AddConnection(connection);
            }

            listener.Stop();
            //TODO: Save DAO
        }
    }
}
