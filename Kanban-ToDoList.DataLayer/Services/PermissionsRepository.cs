// System
using System.Linq;


// Internal
using Kanban_ToDoList.DataLayer.Repository;
using Kanban_ToDoList.DataLayer.Model;



namespace Kanban_ToDoList.DataLayer.Services
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private KanbanToDoListWPFEntities db;
        public PermissionsRepository(KanbanToDoListWPFEntities context)
        {
            db = context;
        }
        public int GetPermissionIdByTitle(string title)
        {
            return db.Permissions.Where(t => t.Title == title).Select(t => t.ID).FirstOrDefault();
        }
    }
}
