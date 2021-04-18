using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;

namespace Server.DAO {
    class ChatDAO : IChatDAO {

        #region Singleton

        private static IChatDAO INSTANCE;
        private static readonly object padlock = new object();

        public static IChatDAO Instance {
            get {
                lock (padlock) {
                    if (INSTANCE == null)
                        INSTANCE = new ChatDAO();
                    return INSTANCE;
                }
            }
        }

        #endregion

        private ICollection<Chat> _chats;

        public ICollection<Chat> chats {
            get {
                return new List<Chat>(_chats);
            }
        }

        private ChatDAO () {
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
            int enumerator = 1;
            foreach(Chat chat in _chats) {
                if(chat.id == 0)
                    chat.id = enumerator;
                enumerator++;
            }
        }
    }
}
