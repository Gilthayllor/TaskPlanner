using Microsoft.AspNetCore.Identity;

namespace TaskPlanner.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual List<TaskItem>? Tasks { get; set; }
    }
}
