namespace TaskPlanner.Entities
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public TaskItem(string title, string description, string idUser)
        {
            Id = Guid.NewGuid().ToString();

            Title = title;
            Description = description;
            UserId = idUser;
        }
    }
}
