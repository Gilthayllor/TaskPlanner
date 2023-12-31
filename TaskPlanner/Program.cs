using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskPlanner.Data;
using TaskPlanner.Entities;
using TaskPlanner.Repositories.Implementations;
using TaskPlanner.Repositories.Interfaces;
using TaskPlanner.Services.Implementations;
using TaskPlanner.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.ExpireTimeSpan = TimeSpan.FromDays(1);
});

builder.Services.AddAuthenticationCore();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

MigrateDabase();

app.Run();

void MigrateDabase()
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();

    if (db.Database.GetMigrations().Any())
        db.Database.Migrate();
}
