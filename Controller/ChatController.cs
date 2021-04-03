using Server.Service;
using Server.Model;
using System.Collections.Generic;

namespace Server.Controller{

    class CharController {
        #region Singleton

        private static CharController INSTANCE;
        private static readonly object padlock = new object();

        public static CharController Instance {
            get {
                lock (padlock){
                    if (INSTANCE == null)
                        INSTANCE = new CharController();
                    return INSTANCE;
                }
            }
        }
        #endregion

        private IChatService iChatService;

        public CharController(){
            iChatService = ChatService.Instance;
        }

        public bool AddUserToChat(Chat chat, User user){
            return iChatService.AddUserToChat(chat, user);
        }

        public Chat CreateChat(){
            return iChatService.CreateChat();
        }

        public Chat GetChatByID(int id){
            return iChatService.GetChatByID(id);
        }

        public Chat GetChatByUser(User user){
            return iChatService.GetChatByUser(user);
        }

        public bool RemoveUserFromChat(Chat chat, User user){
            return iChatService.RemoveUserFromChat(chat, user);
        }
    }
}