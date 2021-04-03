﻿using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;

namespace Server.DAO {
    class UserDAO : IUserDAO {

        #region Singleton

        private static IUserDAO INSTANCE;

        public static IUserDAO Instance {
            get {
                if (INSTANCE == null)
                    INSTANCE = new UserDAO();
                return INSTANCE;
            }
        }

        #endregion

        private ICollection<User> _users; // all registered users

        public ICollection<User> users {
            get {
                return new List<User>(_users);
            }
        }

        public UserDAO () {
            _users = new List<User>();
        }
        public bool AddUser (User user) {
            if (!_users.Contains(user)) {
                _users.Add(user);
                EnumerateAll();
                return true;
            }
            return false;
        }

        public bool RemoveUser (User user) {
            if (_users.Remove(user)) {
                EnumerateAll();
                return true;
            }
            return false;
        }

        private void EnumerateAll () {
            int enumerator = 0;
            foreach(User user in _users) {
                user.id = enumerator;
                enumerator++;
            }
        }
    }
}
