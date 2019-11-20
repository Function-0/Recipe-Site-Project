using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RecipeSite.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace RecipeSite
{
    public class Startup
    {

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:RecipeSiteRepository3:ConnectionString"]));
            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
            services.AddMvc();
        }

      
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "",
            //        template: "{controller=Crud}/{action=Edit}");

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}");
            //});
            SeedData.EnsurePopulated(app);
        }
    }
}
