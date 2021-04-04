using System;
using System.Collections.Generic;

namespace Server.View {

    
    class Navigator {
        private Menu currentMenu;

        public Navigator (Menu menu) {
            currentMenu = menu;
        }

        public void PrintMenu () {
            Console.Write(currentMenu.Name);
            foreach(MenuItem menuItem in currentMenu.GetMenuItems())
                Console.WriteLine(menuItem.GetTitle());
        }

        public void Navigate (int index) {
            List<MenuItem> menuItems = currentMenu.GetMenuItems();
            if(index <= menuItems.Count) {
                if(menuItems[index - 1].GetAction() == null)
                    currentMenu = menuItems[index - 1].GetNextMenu();
                else
                    menuItems[index - 1].DoAction();
        }
        }

    }

    
}