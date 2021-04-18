using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Core {
    class ConnectionService {

        #region Singleton

        private static ConnectionService INSTANCE;
        private static readonly object padlock = new object();

        public static ConnectionService Instance {
            get {
                lock (padlock) {
                    if (INSTANCE == null)
                        INSTANCE = new ConnectionService();
                    return INSTANCE;
                }
            }
        }

        #endregion

        private ICollection<Connection> _connections;

        private ConnectionService () {
            _connections = new List<Connection>();
        }

        public void AddConnection (Connection connection) {
            _connections.Add(connection);
            connection.Run();
        }

        public void Disconnect () {

        }
    }
}
