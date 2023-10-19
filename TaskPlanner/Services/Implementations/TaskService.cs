using AutoMapper;
using TaskPlanner.Entities;
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

        public async Task<TaskItemViewModel> CompleteTask(string id)
        {
            try
            {
                var result = await _taskRepository.GetTaskById(id) ?? throw new Exception("Task não encontrada.");

                result.Completed = true;

                await _taskRepository.UpdateTask(result);

                return _mapper.Map<TaskItemViewModel>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TaskItemViewModel> AddTask(NewTaskViewModel newTaskViewModel, string idUser)
        {
            try
            {
                var newTask = new TaskItem(newTaskViewModel.Description)
                {
                    UserId = idUser,
                };

                var result = await _taskRepository.AddTask(newTask);

                return _mapper.Map<TaskItemViewModel>(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
