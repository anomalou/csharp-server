using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;

namespace Server.Service {
    interface IChatService {
        ChatCover CreateChat ();
        void WriteMessage (ChatCover chat, Message message);
        bool AddUserToChat (ChatCover chat, UserCover user);
        //bool RemoveUserFromChat (Chat chat, User user);
        Chat GetChatByID (int id);
        ICollection<ChatCover> GetChatsByUser (UserCover user);
        bool FindUserInChat (UserCover user, ChatCover chat);
        Message GetLastMessageId (ChatCover chat);
        ICollection<Message> GetLastMessagesFromChat (ChatCover chat, int lastId);
        ChatCover Convert (Chat chat);
    }
}
