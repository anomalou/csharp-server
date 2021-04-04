using System.Collections.Generic;

namespace Server.View {
    class Menu {
        private string name;
        private List<MenuItem> menuItem;


        public Menu () { 
            // this.menuItem = new ArrayList<>();
            this.menuItem = new List<MenuItem>();
        }

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public List<MenuItem> GetMenuItems () {
            return new List<MenuItem>(menuItem);
        }

        public void SetMenuItem (MenuItem menuItem) {
            this.menuItem.Add(menuItem);
        }
    }

}