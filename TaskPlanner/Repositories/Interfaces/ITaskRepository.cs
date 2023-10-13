using TaskPlanner.Entities;

namespace TaskPlanner.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksByUser(string userId);
        Task<TaskItem?> GetTaskById(string id);
        Task<TaskItem> UpdateTask(TaskItem task);
        Task<bool> DeleteTaskById(string id);
    }
}
