using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    enum Status {
        Online,
        Offline
    }
    class User {
        #region Private variables
        private int _id;
        private string _login;
        private string _password;
        private Status _status;
        private string _token;

        //TODO: добавить сюда массив чатов
        #endregion

        #region Params
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
        public Status status {
            get {
                return _status;
            }
            set {
                _status = value;
            }
        }
        public string token {
            get {
                return _token;
            }
            set {
                _token = value;
            }
        } 
        #endregion
    }
}
