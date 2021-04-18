using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class LoginDTO {
        private string _login;
        private string _password;

        public LoginDTO(string login, string password) {
            _login = login;
            _password = password;
        }

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
