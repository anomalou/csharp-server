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
            set {
                if (_users == null)
                    _users = new List<User>();
                _users.Add(value as User);
            }
        }
        public ICollection<Message> messages {
            get {
                if (_messages == null)
                    _messages = new List<Message>();
                return new List<Message>(_messages);
            }
            set {
                if (_messages == null)
                    _messages = new List<Message>();
                _messages.Add(value as Message);
            }
        }
        #endregion
    }
}
