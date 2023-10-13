using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskPlanner.Entities;

namespace TaskPlanner.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskItem>(x =>
            {
                x.ToTable("Tasks");

                x.HasKey(x => x.Id);

                x.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                x.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                x.Property(x => x.UserId)
                    .IsRequired();

                x.HasOne(x => x.User)
                    .WithMany(x => x.Tasks)
                    .HasForeignKey(x => x.UserId);
            });

            var userId = Guid.NewGuid().ToString();

            var applicationUser = new ApplicationUser("Admin", "TaskPlanner")
            {
                UserName = "admin@taskplanner.com",
                Email = "admin@taskplanner.com",
                NormalizedEmail = "ADMIN@TASKPLANNER.COM",
                Id = userId
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            applicationUser.PasswordHash = passwordHasher.HashPassword(applicationUser, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(applicationUser);

            builder.Entity<TaskItem>().HasData(new TaskItem[] {
                new TaskItem("Estudar C#", "Estudar C# durante a noite.") {UserId = userId},
                new TaskItem("Trabalhar", "Trabalhar usando C#.") {UserId = userId},
                new TaskItem("Jantar", "Jantar com minha esposa.") {UserId = userId}
            });

            base.OnModelCreating(builder);
        }
    }
}
