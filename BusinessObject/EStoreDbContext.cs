namespace BusinessObject;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class EStoreDbContext : DbContext
{
    public EStoreDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        IConfiguration configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("EStoreDB"));
    }

    public virtual DbSet<Member>      Members      { get; set; }
    public virtual DbSet<Category>    Categories   { get; set; }
    public virtual DbSet<Order>       Orders       { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<Product>     Products     { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>().HasKey(vf => new { vf.OrderId, vf.ProductId });
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Beverages" },
            new Category { CategoryId = 2, CategoryName = "Condiments" },
            new Category { CategoryId = 3, CategoryName = "Confections" },
            new Category { CategoryId = 4, CategoryName = "Dairy Products" },
            new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
            new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
            new Category { CategoryId = 7, CategoryName = "Produce" },
            new Category { CategoryId = 8, CategoryName = "Seafood" });
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Chai", Weight = 1, CategoryId = 1, UnitPrice = 18.00m, UnitsInStock = 39 },
            new Product { ProductId = 2, ProductName = "Chang", Weight = 1, CategoryId = 1, UnitPrice = 19.00m, UnitsInStock = 17 },
            new Product { ProductId = 3, ProductName = "Aniseed Syrup", Weight = 1, CategoryId = 2, UnitPrice = 10.00m, UnitsInStock = 13 },
            new Product { ProductId = 4, ProductName = "Chef Anton's Cajun Seasoning", Weight = 1, CategoryId = 2, UnitPrice = 22.00m, UnitsInStock = 53 },
            new Product { ProductId = 5, ProductName = "Chef Anton's Gumbo Mix", Weight = 1, CategoryId = 2, UnitPrice = 21.35m, UnitsInStock = 0 },
            new Product { ProductId = 6, ProductName = "Grandma's Boysenberry Spread", Weight = 1, CategoryId = 2, UnitPrice = 25.00m, UnitsInStock = 120 },
            new Product { ProductId = 7, ProductName = "Uncle Bob's Organic Dried Pears", Weight = 1, CategoryId = 7, UnitPrice = 30.00m, UnitsInStock = 15 },
            new Product { ProductId = 8, ProductName = "Northwoods Cranberry Sauce", Weight = 1, CategoryId = 2, UnitPrice = 40.00m, UnitsInStock = 6 },
            new Product { ProductId = 9, ProductName = "Mishi Kobe Niku", Weight = 1, CategoryId = 6, UnitPrice = 97.00m, UnitsInStock = 29 },
            new Product { ProductId = 10, ProductName = "Ikura", Weight = 1, CategoryId = 8, UnitPrice = 31.00m, UnitsInStock = 31 }
            );
        modelBuilder.Entity<Member>().HasData(
            new Member { MemberId = 1, Password = "admin@@", CompanyName = "Administrator", Email = "admin@estore.com", City = "A", Country = "A"},
            new Member { MemberId = 2, Password = "user@@", CompanyName = "User", Email = "a@amail.com", City = "B", Country = "B"},
            new Member { MemberId = 3, Password = "user@@", CompanyName = "User", Email = "b@bmail.com", City = "C", Country = "C"}
            );
        modelBuilder.Entity<Order>().HasData(
            new Order { OrderId = 1, MemberId = 2, OrderDate = DateTime.Now, RequiredDate = DateTime.Today, ShippedDate = DateTime.Today},
            new Order { OrderId = 2, MemberId = 2, OrderDate = DateTime.Now, RequiredDate = DateTime.Today, ShippedDate = DateTime.Today},
            new Order { OrderId = 3, MemberId = 3, OrderDate = DateTime.Now, RequiredDate = DateTime.Today, ShippedDate = DateTime.Today},
            new Order { OrderId = 4, MemberId = 3, OrderDate = DateTime.Now, RequiredDate = DateTime.Today, ShippedDate = DateTime.Today}
            );
        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail { OrderId = 1, ProductId = 1, UnitPrice = 18.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 1, ProductId = 2, UnitPrice = 19.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 1, ProductId = 3, UnitPrice = 10.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 2, ProductId = 4, UnitPrice = 22.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 2, ProductId = 5, UnitPrice = 21.35m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 2, ProductId = 6, UnitPrice = 25.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 3, ProductId = 7, UnitPrice = 30.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 3, ProductId = 8, UnitPrice = 40.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 3, ProductId = 9, UnitPrice = 97.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderId = 4, ProductId = 10, UnitPrice = 31.00m, Quantity = 1, Discount = 0.00f }
            );

    }
}