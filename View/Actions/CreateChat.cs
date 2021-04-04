namespace Server.View {
    class CreateChat : IAction{
    private CharController charController;

        public CreateChat (CharController charController) {
            this.charController = charController;
        }

        public void execute() {
            //создание чата
            charController.CreateChat();
        }
    }
}