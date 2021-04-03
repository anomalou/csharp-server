using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;
using Server.DAO;
using Server.Exceptions;

namespace Server.Service {
    class ChatService : IChatService {

        #region Singleton

        private static IChatService INSTANCE;

        public static IChatService Instance {
            get {
                if (INSTANCE == null)
                    INSTANCE = new ChatService();
                return INSTANCE;
            }
        }

        #endregion

        private IChatDAO chatDAO;

        public ChatService () {
            chatDAO = ChatDAO.Instance;
        }
        public bool AddUserToChat (Chat chat, User user) {
            if (!chat.users.Contains(user)) {
                chat.AddUser(user);
                return true;
            }
            return false;
        }

        public Chat CreateChat () {
            Chat chat = new Chat();
            if (chatDAO.AddChat(chat))
                return chat;
            throw new ChatException();
        }

        public Chat GetChatByID (int id) {
            foreach(Chat chat in chatDAO.chats) {
                if (chat.id == id)
                    return chat;
            }
            throw new ChatException();
        }

        public Chat GetChatByUser (User user) {
            foreach(Chat chat in chatDAO.chats) {
                if (chat.users.Contains(user))
                    return chat;
            }
            throw new ChatException();
        }

        public bool RemoveUserFromChat (Chat chat, User user) {
            if (chat.users.Remove(user))
                return true;
            return false;
        }
    }
}
