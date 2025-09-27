// System
using System;
using System.Collections.Generic;
using System.Linq;


// Internal
using Kanban_ToDoList.DataLayer.Model;
using Kanban_ToDoList.DataLayer.Repository;
using Task = Kanban_ToDoList.DataLayer.Model.Task;



namespace Kanban_ToDoList.DataLayer.Services
{
    public class TasksRepository:ITasksRepository
    {
        private KanbanToDoListWPFEntities db;

        public TasksRepository(KanbanToDoListWPFEntities contect)
        {
            db = contect;
        }

        public bool AddTask(Task task)
        {
            try
            {
                db.Tasks.Add(task);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public IEnumerable<Task> GetAllTasksByUserIdAndStageId(int userId, int stageId)
        {
            return db.Tasks.Where(t => t.UserId == userId && t.StageId == stageId);
        }

        public Task GetTaskById(int taskId)
        {
            return db.Tasks.Find(taskId);
        }

        public bool RemoveTaskById(int taskId)
        {
            var task = db.Tasks.Find(taskId);
            try
            {
                db.Tasks.Remove(task);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool UpdateTask(Task task)
        {
            try
            {
                db.Entry(task).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {

                return false;
            }
        }

    }
}
