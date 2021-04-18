using System;
using System.Collections.Generic;

namespace Server.View {
    class MenuItem {
        private string title;
        private Action action;
        private Menu nextMenu;

        public MenuItem (string title, Action action, Menu nextMenu) {
            this.title = title;
            this.action = action;
            this.nextMenu = nextMenu;
        }
        public string GetTitle () {
                return title;
        }

        public Action GetAction () {
            return action;
        }

        public Menu GetNextMenu () {
            return nextMenu;
        }


    }
}