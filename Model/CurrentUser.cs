using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class CurrentUser {
        private int _id;
        private string _login;
        private string _password;
        
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

        public string password {
            get {
                return _password;
            }
            set {
                _password = value;
            }
        }
    }
}
