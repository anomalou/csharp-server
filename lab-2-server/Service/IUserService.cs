using System;
using System.Collections.Generic;
using System.Text;
using Server.Model;

namespace Server.Service {
    interface IUserService {
        bool LoginUser (LoginDTO user, out User outUser);
        bool RegisterUser (LoginDTO user, out User outUser);
        string GetUserData (User user);
        User GetUserByID (int id);
        ICollection<User> GetOnlineUsers ();
        ICollection<User> GetOfflineUsers ();
        Status CheckUserStatus (User user);
    }
}
