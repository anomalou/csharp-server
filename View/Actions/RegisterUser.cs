namespace Server.View {
    class RegisterUser : IAction{
    private UserController userController;

        public RegisterUser (UserController userController) {
            this.userController = userController;
        }

        public void Execute() {
            //регистрация пользователя
            userController.RegisterUser(new User());
        }
    }
}