using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    [Serializable]
    class DTO {
        #region Private variables
        private string _command;
        private string _type;
        private Object[] _params;
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

        public Object[] parameters {
            get {
                return _params;
            }
        }
        #endregion

        public DTO (string command, string type, params Object[] param) {
            _command = command;
            _type = type;
            _params = param;
        }
    }
}
