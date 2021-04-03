using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;
using Server.DAO;
using Server.Exceptions;

namespace Server.Service {
    class UserService : IUserService {

        #region Singleton

        private static IUserService INSTANCE;
        private static readonly object padlock = new object();

        public static IUserService Instance {
            get {
                lock (padlock) {
                    if (INSTANCE == null)
                        INSTANCE = new UserService();
                    return INSTANCE;
                }
            }
        }

        #endregion

        private IUserDAO userDAO;

        public UserService () {
            userDAO = UserDAO.Instance;
        }
        public Status CheckUserStatus (User user) {
            return user.status;
        }

        public ICollection<User> GetOfflineUsers () {
            ICollection<User> users = new List<User>();
            foreach(User user in userDAO.users) {
                if (user.status == Status.Offline)
                    users.Add(user);
            }
            return users;
        }

        public ICollection<User> GetOnlineUsers () {
            ICollection<User> users = new List<User>();
            foreach (User user in userDAO.users) {
                if (user.status == Status.Online)
                    users.Add(user);
            }
            return users;
        }

        public User GetUserByID (int id) {
            foreach(User user in userDAO.users) {
                if (user.id == id)
                    return user;
            }
            throw new UserException();
        }

        public string GetUserData (User user) {
            return user.ToString();
        }

        public bool RegisterUser (User user) {
            foreach(User u in userDAO.users) {
                if (u.login == user.login)
                    return false;
            }
            userDAO.AddUser(user);
            return true;
        }
    }
}
