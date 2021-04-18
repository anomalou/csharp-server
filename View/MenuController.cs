using System;

namespace Server.View {
    class MenuController {
        private Builder builder;
        private Navigator navigator;

        public MenuController(Builder builder, Navigator navigator) {
            this.builder = builder;
            this.navigator = navigator;
        }

        public void Run () {
            while (true) {
                navigator.PrintMenu();
                navigator.Navigate(int.Parse(Console.ReadLine()));
            }
        }
    }
}