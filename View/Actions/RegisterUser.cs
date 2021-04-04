namespace Server.View {
    class RegisterUser : IAction{
    private UserController userController;

        public RegisterUser (UserController userController) {
            this.userController = userController;
        }

        public void execute() {
            //регистрация пользователя
            userController.RegisterUser(new User());
        }
    }
}