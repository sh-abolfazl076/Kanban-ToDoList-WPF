// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Internal
using Kanban_ToDoList.DataLayer.Model;
using Kanban_ToDoList.DataLayer.Repository;


namespace Kanban_ToDoList.DataLayer.Services
{
    public class UserRepository : IUsersRepository
    {
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FilterUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public int LoginUserByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
