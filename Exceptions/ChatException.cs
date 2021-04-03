using System;
using System.Collections.Generic;
using System.Text;


namespace Server.Exceptions {
    class ChatException : Exception{
        public ChatException () : base("Chat exception!"){}
    }
}
