using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class Chat {
        #region Private variables
        private int _id;
        private ICollection<User> _users;
        private ICollection<Message> _messages;
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
        public ICollection<User> users {
            get {
                if (_users == null)
                    _users = new List<User>();
                return new List<User>(_users);
            }
        }
        public ICollection<Message> messages {
            get {
                if (_messages == null)
                    _messages = new List<Message>();
                return new List<Message>(_messages);
            }
        }
        #endregion

        public Chat () {
            _messages = new List<Message>();
            _users = new List<User>();
        }

        public void AddUser(User user) {
            _users.Add(user);
        }

        public void AddMessage(Message message) {
            _messages.Add(message);
        }
    }
}
