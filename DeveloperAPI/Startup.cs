using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using DeveloperAPI.Models;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Data.Entity;

namespace DeveloperAPI
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.

            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath).AddJsonFile("config.json").AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            //if (env.IsDevelopment())
            //{
            //    // This reads the configuration keys from the secret store.
            //    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            //    builder.AddUserSecrets();
            //}
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework().AddSqlServer().AddDbContext<ScrumDataContext>(options => options.UseSqlServer(Configuration["Data:ScrumDataContext:ConnectionString"])); ;
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes => {
                //routes.MapRoute("DocPage", "documentation/api", new { controller = "home", action = "index" });//pass routing to angular
                routes.MapRoute("Default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
