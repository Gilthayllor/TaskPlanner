namespace TaskPlanner.ViewModels
{
    public class TaskItemViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; }

        public TaskItemViewModel(string id, string description, bool completed, string userId)
        {
            Id = id;
            Description = description;
            Completed = completed;
            UserId = userId;
        }
    }
}
