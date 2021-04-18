using Server.Controller;
using Server.Core;

namespace Server.View{
    delegate void Action();

    class ActionService{
//TODO: 
        public static Action runServer = () => {
            Server.Core.Server.Instance.Run();
        };
        public static Action stopServer = () => {
            Server.Core.Server.Instance.isRunning = false;
        };

        public static Action printUsersList = () => {
            System.Console.WriteLine("here will be users list");
            //TODO: get users list 
        };

        public static Action printChats = () => {
            System.Console.WriteLine("here will be all chat names");
            //TODO: get chats list
        };
    }
}