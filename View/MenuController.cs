using System;

namespace Server.View {
    class MenuController {
        private Builder builder;
        private Navigator navigator;

        public void Run () {
            while (true) {
                navigator.PrintMenu();
                navigator.Navigate(1);
            }
        }
    }
}