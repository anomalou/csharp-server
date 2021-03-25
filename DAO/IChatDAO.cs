using System;
using System.Collections.Generic;
using System.Text;
using Server.Model;

namespace Server.DAO {
    interface IChatDAO {
        bool AddChat (Chat chat);
        bool RemoveChat (Chat chat);
        ICollection<Chat> GetChats ();
    }
}
