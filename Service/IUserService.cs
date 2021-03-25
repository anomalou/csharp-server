using System;
using System.Collections.Generic;
using System.Text;
using Server.Model;

namespace Server.Service {
    interface IUserService {
        bool RegisterUser (User user);
        string GetUserData (User user);
        User GetUserByID (int id);
        ICollection<User> GetOnlineUsers ();
        ICollection<User> GetOfflineUsers ();
        Status CheckUserStatus (User user);
    }
}
