using AutoMapper;
using TaskPlanner.Repositories.Interfaces;
using TaskPlanner.Services.Interfaces;
using TaskPlanner.ViewModels;

namespace TaskPlanner.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TaskService(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public Task<bool> DeleteTaskById(string id)
        {
            try
            {
                return _taskRepository.DeleteTaskById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TaskItemViewModel>> GetAllTasksByUser(string userId)
        {
            try
            {
                var result = await _taskRepository.GetAllTasksByUser(userId);
                return _mapper.Map<IEnumerable<TaskItemViewModel>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<TaskItemViewModel>> GetAllTasks()
        {
            try
            {
                var result = await _taskRepository.GetAllTasks();
                return _mapper.Map<IEnumerable<TaskItemViewModel>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaskItemViewModel?> GetTaskById(string id)
        {
            try
            {
                var result = await _taskRepository.GetTaskById(id);

                return result is null ? throw new Exception("Task não encontrada.") : _mapper.Map<TaskItemViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaskItemViewModel> UpdateTask(TaskItemViewModel task)
        {
            try
            {
                var result = await _taskRepository.GetTaskById(task.Id) ?? throw new Exception("Task não encontrada.");

                _mapper.Map(task, result);

                await _taskRepository.UpdateTask(result);

                return _mapper.Map<TaskItemViewModel>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
