using System;
using System.Collections.Generic;
using System.Text;
using Server.Model;

namespace Server.Service {
    interface IUserService {
        bool LoginUser (LoginDTO user);
        bool RegisterUser (LoginDTO user);
        string GetUserData (User user);
        User GetUserByID (int id);
        ICollection<User> GetOnlineUsers ();
        ICollection<User> GetOfflineUsers ();
        Status CheckUserStatus (User user);
    }
}
