using TaskPlanner.ViewModels;

namespace TaskPlanner.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemViewModel>> GetAllTasks();
        Task<IEnumerable<TaskItemViewModel>> GetAllTasksByUser(string userId);
        Task<TaskItemViewModel> AddTask(NewTaskViewModel newTaskViewModel, string idUser);
        Task<TaskItemViewModel?> GetTaskById(string id);
        Task<TaskItemViewModel> CompleteTask(string id);
        Task<bool> DeleteTaskById(string id);
    }
}
