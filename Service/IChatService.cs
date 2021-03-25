﻿using System;
using System.Collections.Generic;
using System.Text;

using Server.Model;

namespace Server.Service {
    interface IChatService {
        Chat CreateChat ();
        bool AddUserToChat (Chat chat, User user);
        bool RemoveUserFromChat (Chat chat, User user);
        Chat GetChatByID (int id);
        Chat GetChatByUser (User user);
    }
}