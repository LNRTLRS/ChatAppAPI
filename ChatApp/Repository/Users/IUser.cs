using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Repository.Users
{
    public interface IUser
    {
        IList<User> GetUsers();
        void AddUser(User user);
        void RemoveUser(int id);
        void ChangeUsername(int id, string newUsername);
        User GetUser(int id);
    }
}
