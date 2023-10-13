namespace TaskPlanner.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IdUser { get; set; }
        public virtual User? User { get; set; }

        public Task(string title, string description, string idUser)
        {
            Title = title;
            Description = description;
            IdUser = idUser;
        }
    }
}
