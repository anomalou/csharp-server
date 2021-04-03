using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;

namespace Server.DAO {
    class ChatDAO : IChatDAO {

        #region Singleton

        private static IChatDAO INSTANCE;

        public static IChatDAO Instance {
            get {
                if (INSTANCE == null)
                    INSTANCE = new ChatDAO();
                return INSTANCE;
            }
        }

        #endregion

        private ICollection<Chat> _chats;

        public ICollection<Chat> chats {
            get {
                return new List<Chat>(_chats);
            }
        }

        public ChatDAO () {
            _chats = new List<Chat>();
        }
        public bool AddChat (Chat chat) {
            if (!_chats.Contains(chat)) {
                _chats.Add(chat);
                EnumerateAll();
                return true;
            }
            return false;
        }

        public bool RemoveChat (Chat chat) {
            if (_chats.Remove(chat)) {
                EnumerateAll();
                return true;
            }
            return false;
        }

        private void EnumerateAll () {
            int enumerator = 0;
            foreach(Chat chat in _chats) {
                chat.id = enumerator;
                enumerator++;
            }
        }
    }
}
