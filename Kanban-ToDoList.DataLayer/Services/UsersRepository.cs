// System
using System.Linq;
using System.Collections.Generic;



// Internal
using Kanban_ToDoList.DataLayer.Model;
using Kanban_ToDoList.DataLayer.Repository;
using User = Kanban_ToDoList.DataLayer.Model.User;


namespace Kanban_ToDoList.DataLayer.Services
{
    public class UsersRepository : IUsersRepository
    {
        private KanbanToDoListWPFEntities db;

        public UsersRepository(KanbanToDoListWPFEntities context)
        {
            db = context;
        }
        
        public bool AddUser(User user)
        {
            try
            {
                db.Users.Add(user);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public IEnumerable<User> FilterUserByUsername(string username)
        {
            return db.Users.Where(f => f.UserName.Contains(username));
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return db.Users.Find(userId);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username && u.PassWord == password);
        }

        public User GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }

        public bool RemoveUserById(int userId)
        {
            try
            {
                var user = GetUserById(userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    return true;
                }
                return false;
            }
            catch 
            {

                return false ;
            }
        }

        public bool UpdataUser(User user)
        {
            try
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
