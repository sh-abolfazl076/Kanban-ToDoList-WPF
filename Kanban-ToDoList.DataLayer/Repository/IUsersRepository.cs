// System
using System.Collections.Generic;


// Internal
using Kanban_ToDoList.DataLayer.Model;


namespace Kanban_ToDoList.DataLayer.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> FilterUserByUsername(string username);
        bool AddUser(User user);  
        User GetUserById(int userId);
        User GetUserByUsernameAndPassword(string username, string password);
        User GetUserByUsername(string username);
        bool RemoveUserById(int userId);
        bool UpdataUser(User user);
    }
}
