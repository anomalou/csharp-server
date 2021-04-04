using Server.Controller;
using Server.Core;

namespace Server.View {

    class Builder {
        private Menu rootMenu;

        public void BuildMenu () {
            // Menu serverControl = new Menu();
            
            rootMenu = new Menu();
            rootMenu.Name = "Main menu";

            MenuItem startServer = new MenuItem("Start server", ActionService.runServer, null);
            MenuItem stopServer = new MenuItem("Stop server", ActionService.stopServer, null);
            MenuItem printUsersList = new MenuItem("Get users list", ActionService.printUsersList, null);
            MenuItem printChats = new MenuItem("Print all chats ", ActionService.printChats, null);

            // rootMenu.SetMenuItem(new MenuItem("Server control", null, serverControl));
            rootMenu.AddMenuItem(startServer);
            rootMenu.AddMenuItem(stopServer);
            rootMenu.AddMenuItem(printUsersList);
            rootMenu.AddMenuItem(printChats);
            
            
    }

    }

   
}