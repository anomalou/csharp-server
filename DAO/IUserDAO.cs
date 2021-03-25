using System;
using System.Collections.Generic;
using System.Text;
using Server.Model;

namespace Server.DAO {
    interface IUserDAO {
        bool AddUser (User user);
        bool RemoveUser (User user);
        ICollection<User> GetUsers ();
    }
}
