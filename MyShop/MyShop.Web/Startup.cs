using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using MyShop.IoC;


namespace MyShop.Web
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIoCServices(Configuration);
            services.AddControllersWithViews();
            //services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = 6000000;
            //});
            #region Authentication
            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(op =>
            {
                op.LoginPath = "/auth/login";
                op.LogoutPath = "/auth/logout";
                op.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-6.0
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async u =>
            {
                await u.Response.WriteAsync("Hello World!");
            });
        }
    }
}
