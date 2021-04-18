using System;
using System.Collections.Generic;
using Server.Controller;
using Server.Core;
using Server.Model;

namespace Server.View{
    delegate void Action();

    class ActionService{
        public static Action runServer = () => {
            ServerEntity.Instance.Run();
        };
        public static Action stopServer = () => {
            ServerEntity.Instance.Stop();
        };

        public static Action printOnlineUsersList = () => {
            foreach(User user in UserController.Instance.GetOnlineUsers()) {
                Console.WriteLine(user.ToString());
            }
        };

        public static Action printOfflineUsersList = () => {
            foreach (User user in UserController.Instance.GetOfflineUsers()) {
                Console.WriteLine(user.ToString());
            }
        };
    }
}