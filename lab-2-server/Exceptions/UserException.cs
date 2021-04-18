using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Exceptions {
    class UserException : Exception{
        public UserException () : base("User exception!") { }
    }
}
