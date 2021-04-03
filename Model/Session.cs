using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class Session {
        private User _user;

        public User user {
            get {
                return _user;
            }
            set {
                _user = value;
            }
        }

        private void Execution () {
            //handling user session
        }
    }
}
