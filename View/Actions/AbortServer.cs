namespace Server.View {
    class AbortServer : IAction{
    private ServerController serverController;

        public AbortServer (ServerController serverController) {
            this.serverController = serverController;
        }

        public void execute() {
            //остановка сервера;
        }
    }
}