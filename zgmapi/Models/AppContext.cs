using Microsoft.EntityFrameworkCore;
using zgmapi.Models;

public class AppContext : DbContext
{
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public AppContext(DbContextOptions<AppContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
                new Role {Id = 1, Name = "admin" }
        );


        modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "admin", Phone = "777", Password = "admin", RoleId = 1 }
        );
    }
}