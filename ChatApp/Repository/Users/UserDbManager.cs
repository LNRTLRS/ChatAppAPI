using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ChatApp.Repository.Users
{
    public class UserDbManager : IUser
    {
        private LiteDatabase Database { get; } = new LiteDatabase("database.db");
        public void AddUser(User user)
        {
            Users.Insert(user);
        }
        public User GetUser(int id)
        {
            return Users.FindById(id);
        }
        public void RemoveUser(int id)
        {
            Users.Delete(id);
        }
        public void ChangeUsername(int id, string newUsername)
        {
            User u = GetUser(id);
            u.Username = newUsername;
            Users.Update(u);
        }
        public Boolean CheckPass(int id, string pass)
        {
            return GetUser(id).Password == pass;
        }
        public IList<User> GetUsers()
        {
            return Users.FindAll().ToList();
        }

        public LiteCollection<User> Users
        {
            get
            {
                return Database.GetCollection<User>("Users");
            }
        }
    }
}
