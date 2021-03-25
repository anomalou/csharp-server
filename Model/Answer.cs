using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    [Serializable]
    class Answer {
        #region Private variables
        private Object _data;
        #endregion

        #region Params
        public Object data {
            get {
                return _data;
            }
        }
        #endregion
    }
}
