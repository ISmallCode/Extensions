using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmallCode.AspNetCore.Extensions.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SmallCode.AspCore.Extensions.Sample.Models;
using Microsoft.EntityFrameworkCore;
using SmallCode.AspNetCore.Extensions.Middlewares;
using SmallCode.AspCore.Extensions.Sample.Controllers;

namespace SmallCode.AspCore.Extensions.Sample
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SampleContext>(option => option.UseNpgsql(Configuration.GetConnectionString("PostgreSql")));

            services.AddMvc();
        }

        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseSCAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            }
           );
            await SampleData.InitDB(app.ApplicationServices);
        }
    }
}
