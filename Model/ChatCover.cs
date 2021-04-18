using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model {
    class ChatCover {
        private int _id;
        private ICollection<UserCover> _users;
        private ICollection<Message> _messages;

        public int id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }

        public ICollection<UserCover> users {
            get {
                return new List<UserCover>(_users);
            }
        }

        public ICollection<Message> messages {
            get {
                return new List<Message>(_messages);
            }
        }

        public ChatCover () {
            _users = new List<UserCover>();
            _messages = new List<Message>();
        }

        public void AddUser(UserCover user) {
            _users.Add(user);
        }

        public void AddMessages(Message[] messages) {
            foreach(Message m in messages) {
                _messages.Add(m);
            }
        }
    }
}
