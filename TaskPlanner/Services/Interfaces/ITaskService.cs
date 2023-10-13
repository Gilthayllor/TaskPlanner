using TaskPlanner.ViewModels;

namespace TaskPlanner.Services.Interfaces
{
    public interface ITaskservice
    {
        Task<IEnumerable<TaskItemViewModel>> GetAllTasksByUser(string userId);
        Task<TaskItemViewModel?> GetTaskById(string id);
        Task<TaskItemViewModel> UpdateTask(TaskItemViewModel task);
        Task<bool> DeleteTaskById(string id);
    }
}
