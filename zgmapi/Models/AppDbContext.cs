using Microsoft.EntityFrameworkCore;
using zgmapi.Data;

namespace zgmapi.Models;

public class AppDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Status> Status { get; set; } = null!;
    public DbSet<Category> Category { get; set; } = null!;
    public DbSet<Product> Product { get; set; } = null!;
    public DbSet<ProductItem> ProductItem { get; set; } = null!;
    public DbSet<Stock> Stock { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role() {Id = 1, Name = DefaultRoles.AdminString},
            new Role() {Id = 2, Name = DefaultRoles.UserString}
        );
        
        modelBuilder.Entity<Stock>().HasData(
            new Stock() {Id = 1, Title = "Сухой склад", Address = "Проспект Чулман, 40, Набережные Челны, РТ", Descriptions = "Относительная влажность в помещении должна составлять от 50 до 70%, температура – от +5 до +18"}
        );
        
        modelBuilder.Entity<Status>().HasData(
            new Status() {Id = 1, Current = "У поставщика"},
            new Status() {Id = 2, Current = "На складе"},
            new Status() {Id = 3, Current = "Ожидает доставки"}
        );
        
        modelBuilder.Entity<Category>().HasData(
            new Category() {Id = 1, Title = "Игрушки"},
            new Category() {Id = 2, Title = "Лекарства"},
            new Category() {Id = 3, Title = "Напитки"}
        );
        
        modelBuilder.Entity<Product>().HasData(
            new Product() {Id = 1, Title = "Трансформер", CategoryId = 1, DefaultPrice = 350.5},
            new Product() {Id = 2, Title = "Кола", CategoryId = 3, DefaultPrice = 99.99},
            new Product() {Id = 3, Title = "Активированный уголь", CategoryId = 2, DefaultPrice = 100}
        );
        
        modelBuilder.Entity<ProductItem>().HasData(
            new ProductItem() {Id = 3, ProductId = 1, Discount = 10, StockId = 1, Count = 10, Expiration = new DateTime(2023, 12, 1)}
        );


        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "admin", Phone = "777", Password = "admin", RoleId = DefaultRoles.Admin },
            new User { Id = 2, Name = "Александ", Phone = "888", Password = "test", RoleId = DefaultRoles.User, LastName = "Вотяков"}
        );
    }
}