using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    [Serializable]
    class DTO {
        #region Private variables
        private string _command;
        private string _type;
        private object _returnedValue;
        private object[] _params;
        #endregion

        #region Params
        public string command {
            get {
                return _command;
            }
        }
        public string type {
            get {
                return _type;
            }
        }

        public object returnedValue {
            get {
                return _returnedValue;
            }
        }

        public object[] parameters {
            get {
                return _params;
            }
        }
        #endregion

        public DTO (string command, string type, object returnedValue, params object[] param) {
            _command = command;
            _type = type;
            _returnedValue = returnedValue;
            _params = param;
        }
    }
}
