namespace Server.View {
    class GetOnlineUsers : IAction{
    private UserController userController;

        public GetOnlineUsers (UserController userController) {
            this.userController = userController;
        }

        public void Execute() {
            //получение онлайн пользователей
            userController.GetOnlineUsers();
        }
    }
}