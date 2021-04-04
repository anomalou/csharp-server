namespace Server.View {
    class GetChatByUser : IAction{
    private CharController charController;
    private UserController userController;

        public GetChatByUser (CharController charController, UserController userController) {
            this.charController = charController;
            this.userController = userController;
        }

        public void execute() {
            //получение чатов пользователя
            charController.GetChatByUser(userController.GetUserByID(Console.ReadLine()));
        }
    }
}