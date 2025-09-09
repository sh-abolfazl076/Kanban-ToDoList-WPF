// System
using System.Collections.Generic;
using System.Threading.Tasks;

// Internal



namespace Kanban_ToDoList.DataLayer.Repository
{
    public interface ITasksRepository
    {
        bool AddTask(Task task);
        IEnumerable<Task> GetAllTasksByUserIdAndStageId(int userId,int stageId);
        Task GetTaskById(int taskId);
        bool UpdateTask(Task task);
        bool RemoveTaskById(int taskId);

    }
}
