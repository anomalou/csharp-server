namespace Server.View {
    class GetOfflineUsers : IAction{
    private UserController userController;

        public GetOfflineUsers (UserController userController) {
            this.userController = userController;
        }

        public void execute() {
            //получение офлайн пользователей
            userController.GetOfflineUsers();
        }
    }
}