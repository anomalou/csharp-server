namespace Server.View {
    class StartServer : IAction{
    private ServerController serverController;

        public StartServer (ServerController serverController) {
            this.serverController = serverController;
        }

        public void execute() {
            //запуск сервера;
        }
    }
}