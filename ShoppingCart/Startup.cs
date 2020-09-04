using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace ShoppingCart
{
    public class Startup
    {
        public IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString
                ("AppConnectionString")));

            //services.AddScoped<ICategoryRepository, MockCategoryRepository>();
            //services.AddScoped<ICourseRepository, MockCourseRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<ICourseRepository, EFCourseRepository>();
            services.AddControllersWithViews();
            services.AddScoped<MyShoppingCart>(s => MyShoppingCart.GetShoppingCart(s));
            services.AddHttpContextAccessor();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{Id?}"
                    );
            });
        }
    }
}
