namespace Server.View {
    class GetUserData : IAction{
    private UserController userController;

        public GetUserData (UserController userController) {
            this.userController = userController;
        }

        public void execute() {
            //получение данных о пользователей
            userController.GetUserData(userController.GetUserByID(Console.ReadLine()));
        }
    }
}