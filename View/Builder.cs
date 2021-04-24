using Server.Controller;
using Server.Core;

namespace Server.View {

    class Builder {
        private Menu _rootMenu;

        public Menu rootMenu {
            get {
                return _rootMenu;
            }
        }

        public void BuildMenu () {
            // Menu serverControl = new Menu();
            
            _rootMenu = new Menu();
            rootMenu.Name = "Main menu";

            MenuItem startServer = new MenuItem("Start server", ActionService.RunServer, null);
            MenuItem stopServer = new MenuItem("Stop server", ActionService.StopServer, null);
            MenuItem showLog = new MenuItem("Log", ActionService.Log, null);
            // MenuItem printOnlineUsersList = new MenuItem("Get online users list", ActionService.printOnlineUsersList, null);
            // MenuItem printOfflineUsersList = new MenuItem("Get offline users list", ActionService.printOfflineUsersList, null);

            // rootMenu.SetMenuItem(new MenuItem("Server control", null, serverControl));
            rootMenu.AddMenuItem(startServer);
            rootMenu.AddMenuItem(stopServer);
            rootMenu.AddMenuItem(showLog);
            // rootMenu.AddMenuItem(printOnlineUsersList);
            // rootMenu.AddMenuItem(printOfflineUsersList);
        }
    }
}