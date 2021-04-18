using System;
using Server.View;

namespace Server {
    class Program {
        static void Main (string[] args) {
            Builder builder = new Builder();
            builder.BuildMenu();
            Navigator navigator = new Navigator(builder.rootMenu);

            MenuController menuController = new MenuController(builder, navigator);
            menuController.Run();
        }
    }
}
