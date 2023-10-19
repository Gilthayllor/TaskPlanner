namespace TaskPlanner.Entities
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser? User { get; set; }

        public TaskItem(string description)
        {
            Id = Guid.NewGuid().ToString();

            Description = description;
        }
    }
}
