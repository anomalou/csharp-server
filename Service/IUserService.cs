using System.Collections.Generic;
using Server.Model;
using F10Libs.Networkdata;

namespace Server.Service {
    interface IUserService {
        bool LoginUser (CurrentUser user, out CurrentUser outUser);
        bool RegisterUser (CurrentUser user);
        ICollection<UserCover> GetUsers ();
        //string GetUserData (User user);
        User GetUserByID(int id);
        //ICollection<User> GetOnlineUsers ();
        //ICollection<User> GetOfflineUsers ();
        //Status CheckUserStatus (User user);
        UserCover Convert (User user);
        CurrentUser ConvertToCurrentUser (User user);
    }
}
