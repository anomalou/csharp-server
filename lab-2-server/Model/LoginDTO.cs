using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class LoginDTO {
        private string _login;
        private string _password;

        public string login {
            get {
                return _login;
            }
        }

        public string password {
            get {
                return _password;
            }
        }
    }
}
