using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class UserCover {
        private int _id;
        private string _login;

        public int id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }

        public string login {
            get {
                return _login;
            }
            set {
                _login = value;
            }
        }
    }
}
