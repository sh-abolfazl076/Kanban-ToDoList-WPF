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
        int LoginUserByUsernameAndPassword(string username, string password);

    }
}
