using Microsoft.EntityFrameworkCore;
using TaskPlanner.Data;
using TaskPlanner.Entities;
using TaskPlanner.Repositories.Interfaces;

namespace TaskPlanner.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _dataContext;

        public TaskRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> DeleteTaskById(string id)
        {
            var task = await _dataContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return false;

            _dataContext.Tasks.Remove(task);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksByUser(string userId)
        {
            return await _dataContext.Tasks.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _dataContext.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskById(string id)
        {
            return await _dataContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskItem> UpdateTask(TaskItem task)
        {
            _dataContext.Tasks.Update(task);
            await _dataContext.SaveChangesAsync();

            return task;
        }
    }
}
