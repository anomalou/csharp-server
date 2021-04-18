using Server.Service;
using Server.Model;
using System.Collections.Generic;

namespace Server.Controller{

    class ChatController {
        #region Singleton

        private static ChatController INSTANCE;
        private static readonly object padlock = new object();

        public static ChatController Instance {
            get {
                lock (padlock){
                    if (INSTANCE == null)
                        INSTANCE = new ChatController();
                    return INSTANCE;
                }
            }
        }
        #endregion

        private IChatService iChatService;

        private ChatController(){
            iChatService = ChatService.Instance;
        }

        public bool AddUserToChat(Chat chat, User user){
            return iChatService.AddUserToChat(chat, user);
        }

        public Chat CreateChat(){
            return iChatService.CreateChat();
        }

        public void WriteMessage(Chat chat, Message message) {
            iChatService.WriteMessage(chat, message);
        }

        public Chat GetChatByID(int id){
            return iChatService.GetChatByID(id);
        }

        public ICollection<Chat> GetChatByUser(User user){
            return iChatService.GetChatsByUser(user);
        }

        //public bool RemoveUserFromChat(Chat chat, User user){
        //    return iChatService.RemoveUserFromChat(chat, user);
        //}
    }
}