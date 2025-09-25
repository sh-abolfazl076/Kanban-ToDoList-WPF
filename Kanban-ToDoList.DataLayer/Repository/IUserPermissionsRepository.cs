// System
using Kanban_ToDoList.DataLayer.Model;


// Internal




namespace Kanban_ToDoList.DataLayer.Repository
{
    public interface IUserPermissionsRepository
    {
        bool AddUserPermission(UserPermission  userPermission);
        UserPermission CheckPermission(int userId, int permissionId);
        UserPermission GetUserPermissionById(int permissionId);
        bool RemoveUserPermission(int permissionId);
        bool RemoveUserPermissionByUserId(int userId);
    }
}
