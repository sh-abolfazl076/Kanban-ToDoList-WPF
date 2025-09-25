// System
using Kanban_ToDoList.DataLayer.Model;


// Internal




namespace Kanban_ToDoList.DataLayer.Repository
{
    public interface IUserPermissionsRepository
    {
        bool AddUserPermission(UserPermission  userPermission);
        bool CheckPermission(int userId, int permissionId);
    }
}
