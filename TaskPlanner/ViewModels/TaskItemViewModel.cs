namespace TaskPlanner.ViewModels
{
    public class TaskItemViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; }

        public TaskItemViewModel(string id, string title, string description, bool completed, string userId)
        {
            Id = id;
            Title = title;
            Description = description;
            Completed = completed;
            UserId = userId;
        }
    }
}
