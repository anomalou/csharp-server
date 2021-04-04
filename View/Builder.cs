namespace Server.View {

    class Builder {
        private Menu rootMenu;

        public void BuildMenu () {
            // Menu serverControl = new Menu();
            Menu charController = new Menu();
            Menu userController = new Menu();

            rootMenu = new Menu();
            rootMenu.Name = "Main menu";
            // rootMenu.SetMenuItem(new MenuItem("Server control", null, serverControl));
            rootMenu.SetMenuItem(new MenuItem("Chat control", null, charController));
            rootMenu.SetMenuItem(new MenuItem("User control", null, userController));

            // serverControl.Name = "Server's menu";
            // serverControl.SetMenuItem(new MenuItem("Start server", new StartServer(ServerController.GetInstance), null));
            // serverControl.SetMenuItem(new MenuItem("Abort server", new AbortServer(ServerController.GetInstance), null));

            charController.Name = "Chat's menu"
            charController.SetMenuItem(new MenuItem("Create chat", new CreateChat(CharController.GetInstance), null));
            charController.SetMenuItem(new MenuItem("Add user to chat", new AddUserToChat(CharController.GetInstance, UserController.GetInstance), null));
            charController.SetMenuItem(new MenuItem("Get chat by user", new GetChatByUser(CharController.GetInstance, UserController.GetInstance), null));
   
            userController.Name = "User's menu"
            userController.SetMenuItem(new MenuItem("Register user", new RegisterUser(UserController.GetInstance), null));
            userController.SetMenuItem(new MenuItem("Get offline users", new GetOfflineUsers(UserController.GetInstance), null));
            userController.SetMenuItem(new MenuItem("Get online users", new GetOnlineUsers(UserController.GetInstance), null));
            userController.SetMenuItem(new MenuItem("Get user data", new GetUserData(userController.GetInstance), null));
          
    }

    }

   
}