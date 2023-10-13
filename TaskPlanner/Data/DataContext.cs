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

                x.HasOne(x => x.User)
                    .WithMany(x => x.Tasks)
                    .HasForeignKey(x => x.UserId);
            });

            var applicationUser = new ApplicationUser("Admin", "TaskPlanner")
            {
                UserName = "admin@taskplanner.com",
                Email = "admin@taskplanner.com",
                NormalizedEmail = "ADMIN@TASKPLANNER.COM"
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            applicationUser.PasswordHash = passwordHasher.HashPassword(applicationUser, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(applicationUser);

            base.OnModelCreating(builder);
        }
    }
}
