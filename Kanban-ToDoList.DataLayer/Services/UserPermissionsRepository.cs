// System
using System.Linq;


// Internal
using Kanban_ToDoList.DataLayer.Model;
using Kanban_ToDoList.DataLayer.Repository;



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
        public UserPermission CheckPermission(int userId, int permissionId) 
        {
            return db.UserPermissions.FirstOrDefault(p => p.UserId == userId && p.PermissionId == permissionId);
        }
        public UserPermission GetUserPermissionById(int permissionId)
        {
            return db.UserPermissions.Find(permissionId);
        }
        public bool RemoveUserPermission(int permissionId) 
        {
            try
            {
                var permission = GetUserPermissionById(permissionId);
                if (permission != null)
                {
                    db.UserPermissions.Remove(permission);
                    return true;
                }
                return false;
            }
            catch 
            {

                return false;
            }
        }
        public bool RemoveUserPermissionByUserId(int userId)
        {
            try
            {
                var permission = db.UserPermissions.Where(p => p.UserId == userId).ToList();

                if (permission.Any())
                {
                    db.UserPermissions.RemoveRange(permission);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
