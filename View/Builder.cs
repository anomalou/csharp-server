namespace Server.View {

    class Builder {
        private Menu rootMenu;

        public void BuildMenu () {
            Menu serverControl = new Menu();

            rootMenu = new Menu();
            rootMenu.Name = "Main menu";
            rootMenu.SetMenuItem(new MenuItem("Start server", null, serverControl));

            serverControl.Name = "Server's menu";
            serverControl.SetMenuItem(new MenuItem("Start server", new StartServer(ServerController.GetInstance), null));
            serverControl.SetMenuItem(new MenuItem("Abort server", new AbortServer(ServerController.GetInstance), null));
    }

    }

   
}