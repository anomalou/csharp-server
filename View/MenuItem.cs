using System;
using System.Collections.Generic;

namespace Server.View {
    class MenuItem {
        private string title;
        private IAction action;
        private Menu nextMenu;

        public MenuItem (string title, IAction action, Menu nextMenu) {
            this.title = title;
            this.action = action;
            this.nextMenu = nextMenu;
        }
        public string GetTitle () {
                return title;
        }

        public IAction GetAction () {
            return action;
        }

        public Menu GetNextMenu () {
            return nextMenu;
        }

        public void DoAction () {
            action.execute();
        }

    }
}