using System;

namespace Server.Model {
    public class LogMessage {
        private DateTime _time;
        private string _message;

        public DateTime time {
            get{ return _time; }
        }

        public string message {
            get{ return _message; }
        }

        public LogMessage(DateTime time, string message) {
            _time = time;
            this._message = message;
        }
    }
}