using System;
using System.Collections.Generic;
using System.Text;
using Server.Core;
using Server.DAO;
using Server.Exceptions;
using F10Libs.Networkdata;
using Server.Model;

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
            return GetUserByID(user.id).status;
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

        public string GetUserData (User user) {
            return GetUserByID(user.id).ToString();
        }

        public ICollection<UserCover> GetUsers () {
            List<UserCover> covers = new List<UserCover>();
            foreach(User user in userDAO.users) {
                covers.Add(Convert(user));
            }
            Logger.Instance.AddMessage($"User get list of all users");
            return covers;
        }

        public User GetUserByID(int id) {
            foreach (User user in userDAO.users) {
                if (user.id == id)
                    return user;
            }
            throw new UserException();
        }

        public bool LoginUser (CurrentUser user, out CurrentUser outUser) {
            foreach(User u in userDAO.users) {
                if(user.Login == u.login && user.HashedPassword == u.password) {
                    outUser = ConvertToCurrentUser(u);
                    Logger.Instance.AddMessage($"User ({user.Id}|{user.Login}) successfully logged");
                    return true;
                }
            }
            Logger.Instance.AddMessage($"User ({user.Id}|{user.Login}) failed to login");
            outUser = null;
            return false;
        }

        public bool RegisterUser (CurrentUser user) {
            foreach(User u in userDAO.users) {
                if (u.login == user.Login) {
                    Logger.Instance.AddMessage($"Registration failed for user ({user.Login})");
                    return false;
                }
            }
            User ur = new User();
            ur.login = user.Login;
            ur.password = user.HashedPassword;
            userDAO.AddUser(ur);
            Logger.Instance.AddMessage($"Registration successfully for user ({ur.id}|{user.Login})");
            return true;
        }

        public UserCover Convert(User user) {
            UserCover cover = new UserCover();
            cover.id = user.id;
            cover.login = user.login;
            return cover;
        }

        public CurrentUser ConvertToCurrentUser (User user) {
            CurrentUser currentUser = new CurrentUser(user.id, user.login, user.password);
            return currentUser;
        }
    }
}
