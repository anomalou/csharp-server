using Server.Service;
using Server.Model;
using System.Collections.Generic;

namespace Server.Controller {

    class UserController{

        #region Singleton
        private static UserController INSTANCE;

        private static readonly object padlock = new object();

        public static UserController Instance {
            get{
                lock(padlock){
                    if(INSTANCE == null)
                        INSTANCE = new UserController();
                    return INSTANCE;
                }
            }

        }


        #endregion

        private IUserService iUserService;

        private UserController() {
            iUserService = UserService.Instance;
        }


        //TODO: сделать конструкторы приватными

        public Status checkUserStatus(User user){
            return iUserService.CheckUserStatus(user);
        }

        public ICollection<User> GetOfflineUsers(){
            return iUserService.GetOnlineUsers();
        }

        public ICollection<User> GetOnlineUsers(){
            return iUserService.GetOnlineUsers();
        }

        public User GetUserByID(int id){
            return iUserService.GetUserByID(id);
        }

        public string GetUserData(User user){
            return iUserService.GetUserData(user);
        }

        public bool LoginUser (LoginDTO user) {
            return iUserService.LoginUser(user);
        }
        public bool RegisterUser(LoginDTO user){
            return iUserService.RegisterUser(user);
        }
        
    }

}