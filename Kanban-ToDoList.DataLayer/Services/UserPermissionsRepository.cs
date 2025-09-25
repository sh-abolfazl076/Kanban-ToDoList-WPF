// System



// Internal
using Kanban_ToDoList.DataLayer.Model;
using Kanban_ToDoList.DataLayer.Repository;
using System.Linq;



namespace Kanban_ToDoList.DataLayer.Services
{
    public class UserPermissionsRepository : IUserPermissionsRepository
    {
        private KanbanToDoListWPFEntities db;
        public UserPermissionsRepository(KanbanToDoListWPFEntities context)
        {
            db = context;
        }
        public bool AddUserPermission(UserPermission userPermission)
        {
            try
            {
                db.UserPermissions.Add(userPermission);
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool CheckPermission(int userId, int permissionId) 
        {
            return db.UserPermissions.Any(p => p.UserId == userId && p.PermissionId == permissionId);
        }

    }
}
