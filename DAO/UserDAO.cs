using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;

namespace Server.DAO {
    class UserDAO : IUserDAO {

        #region Singleton

        private static IUserDAO INSTANCE;
        private static readonly object padlock = new object();

        public static IUserDAO Instance {
            get {
                lock (padlock) {
                    if (INSTANCE == null)
                        INSTANCE = new UserDAO();
                    return INSTANCE;
                }
            }
        }

        #endregion

        private ICollection<User> _users; // all registered users

        public ICollection<User> users {
            get {
                return new List<User>(_users);
            }
        }

        private UserDAO () {
            _users = new List<User>();
        }
        public bool AddUser (User user) {
            if (!_users.Contains(user)) {
                _users.Add(user);
                return true;
            }
            return false;
        }

        public bool RemoveUser (User user) {
            if (_users.Remove(user)) {
                return true;
            }
            return false;
        }
    }
}
