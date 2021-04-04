using System;

namespace Server.View {
    class AddUserToChat : IAction{
    private CharController charController;
    private UserController userController;

        public AddUserToChat (CharController charController, UserController userController) {
            this.charController = charController;
            this.userController = userController;
        }

        public void Execute() {
            //добавление пользователя в чат;
            charController.AddUserToChat(
                charController.GetChatByID(Console.ReadLine()), 
                userController.GetUserByID(Console.ReadLine())
            );            
        }
    }   
}