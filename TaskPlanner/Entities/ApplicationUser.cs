using Microsoft.AspNetCore.Identity;

namespace TaskPlanner.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<TaskItem>? Tasks { get; set; }

        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
