using System;
using System.Collections.Generic;
using Server.Controller;
using Server.Core;
using Server.Model;

namespace Server.View{
    delegate void Action();

    class ActionService{
        public static Action RunServer = () => {
            ServerEntity.Instance.Run();
        };
        public static Action StopServer = () => {
            ServerEntity.Instance.Stop();
        };

        public static Action Log = () => {
            foreach (var s in Logger.Instance.GetLog()) {
                Console.WriteLine(s);
            }
        };

        // public static Action printOnlineUsersList = () => {
        //     foreach(UserCover user in UserController.Instance.GetOnlineUsers()) {
        //         Console.WriteLine(user.ToString());
        //     }
        // };
        //
        // public static Action printOfflineUsersList = () => {
        //     foreach (User user in UserController.Instance.GetOfflineUsers()) {
        //         Console.WriteLine(user.ToString());
        //     }
        // };
    }
}