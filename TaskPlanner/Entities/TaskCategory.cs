namespace TaskPlanner.Entities
{
    public class TaskCategory
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public virtual List<TaskItem>? Tasks { get; set; }

        public TaskCategory(string categoryName)
        {
            Id = Guid.NewGuid().ToString();
            CategoryName = categoryName;
        }
    }
}
