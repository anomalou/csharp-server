using Server.Service;
using Server.Model;
using System.Collections.Generic;

namespace Server.Controller {

    class ChatController {
        #region Singleton

        private static ChatController INSTANCE;
        private static readonly object padlock = new object();

        public static ChatController Instance {
            get {
                lock (padlock) {
                    if (INSTANCE == null)
                        INSTANCE = new ChatController();
                    return INSTANCE;
                }
            }
        }
        #endregion

        private IChatService iChatService;

        private ChatController () {
            iChatService = ChatService.Instance;
        }

        public bool AddUserToChat (ChatCover chat, UserCover user) {
            return iChatService.AddUserToChat(chat, user);
        }

        public ChatCover CreateChat () {
            return iChatService.CreateChat();
        }

        public void WriteMessage (ChatCover chat, Message message) {
            iChatService.WriteMessage(chat, message);
        }

        //public Chat GetChatByID(int id){
        //    return iChatService.GetChatByID(id);
        //}

        public ICollection<ChatCover> GetChatsByUser (UserCover user) {
            return iChatService.GetChatsByUser(user);
        }
    }
}