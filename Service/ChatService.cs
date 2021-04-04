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
        private static readonly object padlock = new object();

        public static IChatService Instance {
            get {
                lock (padlock){
                    if (INSTANCE == null)
                        INSTANCE = new ChatService();
                    return INSTANCE;
                }
            }
        }

        #endregion

        private IChatDAO chatDAO;
        private IUserService userService;

        public ChatService () {
            chatDAO = ChatDAO.Instance;
            userService = UserService.Instance;
        }
        public bool AddUserToChat (Chat chat, User user) {
            if (!FindUserInChat(user, chat)) {
                Chat c = GetChatByID(chat.id);
                User u = userService.GetUserByID(user.id);
                c.AddUser(u);
                u.AddChat(c);
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

        public void WriteMessage (Chat chat, Message message) {
            GetChatByID(chat.id).AddMessage(message);
        }

        public Chat GetChatByID (int id) {
            foreach(Chat chat in chatDAO.chats) {
                if (chat.id == id)
                    return chat;
            }
            throw new ChatException();
        }

        public ICollection<Chat> GetChatsByUser (User user) {
            return new List<Chat>(userService.GetUserByID(user.id).chats);
        }

        //public bool RemoveUserFromChat (Chat chat, User user) {
        //    if (chat.users.Remove(user))
        //        return true;
        //    return false;
        //}

        public bool FindUserInChat (User user, Chat chat) {
            return chat.users.Contains(user);
        }
    }
}
