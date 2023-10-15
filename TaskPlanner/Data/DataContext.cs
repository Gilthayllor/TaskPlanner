using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskPlanner.Entities;

namespace TaskPlanner.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskCategory>(x =>
            {
                x.ToTable("TaskCategories");

                x.HasKey(x => x.Id);

                x.Property(x => x.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                x.HasMany(x => x.Tasks)
                    .WithOne(x => x.Category)
                    .HasForeignKey(x => x.CategoryId);
            });

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

            var userId = "4C4FC1E6-5712-4CFB-9A60-AF38CF80CA81";

            var applicationUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "TaskPlanner",
                UserName = "admin@taskplanner.com",
                Email = "admin@taskplanner.com",
                NormalizedEmail = "ADMIN@TASKPLANNER.COM",
                Id = userId
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            applicationUser.PasswordHash = passwordHasher.HashPassword(applicationUser, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(applicationUser);


            var categoryId = "4B19D44A-7949-421F-B72C-B3C8FF6EB49C";

            builder.Entity<TaskCategory>().HasData(new TaskCategory[]
            {
                new TaskCategory("Work") {Id = categoryId}

            });

            builder.Entity<TaskItem>().HasData(new TaskItem[] {
                new TaskItem("Testar a aplicação TaskPlanner", "Realizar os testes da aplicação e gasrantir que tudo esteja funcionando corretamente.")
                {
                    Id = "B05F1A36-B959-41F7-A66B-CC4D99FB5F06",
                    UserId = userId,
                    CategoryId = categoryId
                },
                new TaskItem("Fazer deploy da aplicação TaskPlanner", "Fazer o deploy da aplicação em produção.")
                {
                    Id = "A12AC436-5B55-44B4-AE71-C20C7948004F",
                    UserId = userId, 
                    CategoryId = categoryId
                }
            });

            base.OnModelCreating(builder);
        }
    }
}
