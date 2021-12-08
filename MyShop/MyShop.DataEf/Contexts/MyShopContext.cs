using System;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities.Orders;
using MyShop.Domain.Entities.Products;
using MyShop.Domain.Entities.Users;

namespace MyShop.DataEf.Contexts
{
    public class MyShopContext : DbContext
    {
        public MyShopContext(DbContextOptions<MyShopContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var date = new DateTime(2021, 10, 27, 17, 35, 00);
            modelBuilder.Entity<ProductGroup>().HasData(new ProductGroup
            {
                Id = 1,
                Title = "گروه اصلی",
                CreateDate = date
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Mobile = "09121425058",
                Email = "mohamadalizadeh989@gmail.com",
                Password = "AHvMzibnzU/XiBqMNVTfHGGoJRDu9CglrvyJW1bDsRE9EnQm7E+mLc94t5fhOBLBvw==", // 1234
                UserName = "mohamadAlizadeh989",
                UserAvatar = "Default.jpg",
                CreateDate = date,
                ActiveCode = Guid.NewGuid().ToString().Replace("-", ""),
                EmailConfirm = true,
                IsActive = true
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
