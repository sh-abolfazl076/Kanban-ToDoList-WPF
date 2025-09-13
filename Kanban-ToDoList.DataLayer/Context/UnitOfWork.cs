// System



// Internal
using Kanban_ToDoList.DataLayer.Model;
using Kanban_ToDoList.DataLayer.Repository;
using Kanban_ToDoList.DataLayer.Services;



namespace Kanban_ToDoList.DataLayer.Context
{
    public class UnitOfWork
    {
        //KanbanToDoListWPFEntities db = new KanbanToDoListWPFEntities();
        private KanbanToDoListWPFEntities db;

        public UnitOfWork(string connectionString)
        {
            db = new KanbanToDoListWPFEntities(connectionString);
        }

        private IUsersRepository _usersRepository;
        public IUsersRepository UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UsersRepository(db);
                }
                return _usersRepository;
            }
        }// End

        private ITasksRepository _tasksRepository;
        public ITasksRepository TasksRepository
        {
            get
            {
                if (_tasksRepository == null)
                {
                    _tasksRepository = new TasksRepository(db);
                }
                return _tasksRepository;
            }
        }// End

        private IUserPermissionsRepository _userPermissionsRepository;
        public IUserPermissionsRepository UserPermissionsRepository
        {
            get
            {
                if (_userPermissionsRepository == null)
                {
                    _userPermissionsRepository = new UserPermissionsRepository(db);
                }
                return _userPermissionsRepository;
            }
        }// End



        //
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
        //
    }
}
