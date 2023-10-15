namespace TaskPlanner.Entities
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
        public virtual ApplicationUser? User { get; set; }
        public virtual TaskCategory? Category { get; set; }

        public TaskItem(string title, string description)
        {
            Id = Guid.NewGuid().ToString();

            Title = title;
            Description = description;
        }
    }
}
