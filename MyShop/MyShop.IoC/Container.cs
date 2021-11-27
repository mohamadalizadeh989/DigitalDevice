using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Security;
using MyShop.DataEf.Contexts;

namespace MyShop.IoC
{
    public static class Container
    {
        public static IServiceCollection AddIoCServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyShopContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("MyShopConnection"));
            });
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IAccountService, AccountService>();

            return services;
        }
    }
}
