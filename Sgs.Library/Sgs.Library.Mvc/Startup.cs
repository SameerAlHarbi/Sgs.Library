using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sameer.Shared.Data;
using Sameer.Shared.Helpers.Mvc;
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
            services.AddSameerDbDataManagers<LibraryDB>(_config);

            services.AddSingleton<IAppInfo, AppInfoManager>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();

            services.AddAutoMapper();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/500");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(configureRoute);
        }

        private void configureRoute(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("HomeAsync", "Books/{action=indexAsync}/{id?}");
            routeBuilder.MapRoute("Default", "{controller=home}/{action=index}/{id?}");
        }
    }
}