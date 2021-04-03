using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    [Serializable]
    class DTO {
        #region Private variables
        private string _command;
        private Object _data;
        #endregion

        #region Params
        public string command {
            get {
                return _command;
            }
        }
        public Object data {
            get {
                return _data;
            }
        }
        #endregion
    }
}
