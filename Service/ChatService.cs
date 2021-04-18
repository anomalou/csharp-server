using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;
using Server.DAO;
using Server.Exceptions;

using Server.Core;
using System.Linq;

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
        public bool AddUserToChat (ChatCover chat, UserCover user) {
            if (!FindUserInChat(user, chat)) {
                Chat c = GetChatByID(chat.id);
                User u = userService.GetUserByID(user.id);
                c.AddUser(u);
                u.AddChat(c);
                return true;
            }
            
            return false;
        }

        public ChatCover CreateChat () {
            Chat chat = new Chat();
            if (chatDAO.AddChat(chat))
                return Convert(chat);
            throw new ChatException();
        }

        public void WriteMessage (ChatCover chat, Message message) {
            GetChatByID(chat.id).AddMessage(message);
        }

        public Chat GetChatByID (int id) {
            foreach(Chat chat in chatDAO.chats) {
                if (chat.id == id)
                    return chat;
            }
            throw new ChatException();
        }

        public ICollection<ChatCover> GetChatsByUser (UserCover user) {
            List<ChatCover> covers = new List<ChatCover>();
            foreach(Chat chat in userService.GetUserByID(user.id).chats) {
                covers.Add(Convert(chat));
            }
            return covers;
        }

        //public bool RemoveUserFromChat (Chat chat, User user) {
        //    if (chat.users.Remove(user))
        //        return true;
        //    return false;
        //}

        public bool FindUserInChat (UserCover user, ChatCover chat) {
            foreach(UserCover userCover in chat.users) {
                if (userCover.id == user.id)
                    return true;
            }
            return false;
        }

        public Message GetLastMessageId (ChatCover chat) {
            try {
                return GetChatByID(chat.id).messages.Last<Message>();
            }catch (Exception ex) {
                return null;
            }
        }

        public ICollection<Message> GetLastMessagesFromChat (ChatCover chat, int lastId) {
            List<Message> messages = new List<Message>();

            Chat c = GetChatByID(chat.id);
            for(int i = lastId; i < c.messages.Count; i++) {
                messages.Add(c.messages.ToList()[i]);
            }

            return messages;
        }

        public ChatCover Convert(Chat chat) {
            ChatCover cover = new ChatCover();
            foreach(User user in chat.users) {
                cover.AddUser(userService.Convert(user));
            }
            cover.AddMessages(chat.messages.ToArray());
            cover.id = chat.id;
            return cover;
        }
    }
}
