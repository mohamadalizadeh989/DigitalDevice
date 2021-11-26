using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var date = new DateTime(2021, 11, 20, 09, 57, 00);
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
                Password = "APQYv1fPpD9GejqGh1qtaxPcc6ioAt8NdaJd85F2/ZoTQHdSADUu91NxflyVMIvceg==", //1234
                FullName = "Mohammad Alizadeh",
                CreateDate = date,
                EmailConfirm = true,
                IsActive = true
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
