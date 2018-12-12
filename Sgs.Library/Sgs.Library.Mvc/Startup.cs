using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sameer.Shared.Data;
using Sameer.Shared.Helpers.Mvc;
using Sgs.Library.BusinessLogic;
using Sgs.Library.DataAccess;
using Sgs.Library.Mvc.Services;

namespace Sgs.Library.Mvc
{
    public class Startup
    {
        private IConfiguration _config;
        private IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDB>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection"))
            ,ServiceLifetime.Scoped);

            services.AddScoped<IRepository, Repository<LibraryDB>>();

            services.AddScoped<BooksManager>();







            services.AddSingleton<IAppInfo, AppInfoManager>();

            services.AddAutoMapper();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(configureRoute);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("not found");
            });
        }

        private void configureRoute(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("managers", "managers/{action=index}/{id?}", defaults: new { controller = "users" });
            routeBuilder.MapRoute("Default", "{controller=home}/{action=index}/{id?}");
        }
    }
}
