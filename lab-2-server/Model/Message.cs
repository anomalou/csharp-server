using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class Message {
        #region Private variables
        private int _id;
        private DateTime _time;
        private User _author;
        private string _text;
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
        public DateTime time {
            get {
                return _time;
            }
            set {
                _time = value;
            }
        }
        public User author {
            get {
                return _author;
            }
            set {
                _author = value;
            }
        }
        public string text {
            get {
                return _text;
            }
            set {
                _text = value;
            }
        }
        #endregion
    }
}
