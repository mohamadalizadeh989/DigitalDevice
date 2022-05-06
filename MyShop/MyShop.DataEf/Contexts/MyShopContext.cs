using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities.Orders;
using MyShop.Domain.Entities.Permissions;
using MyShop.Domain.Entities.Products;
using MyShop.Domain.Entities.Users;
using MyShop.Domain.Entities.Wallet;

namespace MyShop.DataEf.Contexts
{
    public class MyShopContext : DbContext
    {
        public MyShopContext(DbContextOptions<MyShopContext> options) : base(options)
        {

        }

        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Product

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductLevel> ProductLevels { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }

        #endregion

        #region Order

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        #endregion

        #region Wallet

        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        #endregion

        #region Permission

        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var date = new DateTime(2021, 10, 27, 17, 35, 00);
            modelBuilder.Entity<ProductGroup>().HasData(new ProductGroup
            {
                GroupId = 1,
                GroupTitle = "گروه اصلی",
                CreateDate = date
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Mobile = "09121425058",
                Email = "mohamadalizadeh989@gmail.com",
                Password = "AHvMzibnzU/XiBqMNVTfHGGoJRDu9CglrvyJW1bDsRE9EnQm7E+mLc94t5fhOBLBvw==", // 1234
                UserName = "mohamadAlizadeh989",
                UserAvatar = "Default.jpg",
                Skill = "C# Programmer",
                WebSite = "www.digitaldevice.com",
                Bio =
                    "از سال 86 تا 95 مشغول کار طراحی برد الکترونیک و برنامه نویسی با میکرو کنترلر های AVR به زبان بیسیک و کمی تجربه کار با میکروکنترلر های ARM به زبان c بودم و از سال 95 تا 1400 به صورت کامل به کار در حوزه املاک و مستغلات برای کسب تجربه در این زمینه و شناسایی نیازهای فراوان این فیلد مشغول بودم و با شروع آموزش برنامه نویسی C# و ASP.NET CORE از ابتدای سال 1400 تصمیم به انجام پروژه ها و رفع نیازهای این شغل گرفتم.rاز شروع با برنامه نویسی C# علاقه شدیدی در این زمینه برای من ایجاد شد.",
                CreateDate = date,
                ActiveCode = Guid.NewGuid().ToString().Replace("-", ""),
                IsActive = true
            });

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDelete);
            modelBuilder.Entity<Product>().HasQueryFilter(r => !r.IsDelete);
            modelBuilder.Entity<ProductGroup>().HasQueryFilter(g => !g.IsDelete);
            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Permission>().HasKey(r => r.PermissionId);
            modelBuilder.Entity<RolePermission>().HasKey(r => r.RP_Id);


            base.OnModelCreating(modelBuilder);
        }

    }
}

