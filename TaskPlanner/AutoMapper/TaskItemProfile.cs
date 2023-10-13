using AutoMapper;
using TaskPlanner.Entities;
using TaskPlanner.ViewModels;

namespace TaskPlanner.AutoMapper
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemViewModel>();
        }
    }
}
