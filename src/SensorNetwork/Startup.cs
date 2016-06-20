using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using SensorNetwork.Controllers.App;
using SensorNetwork.Models.DbContexts;
using SensorNetwork.Models.RepositoryPattern;
using SensorNetwork.Models;
using Newtonsoft.Json.Serialization;

namespace SensorNetwork
{
    public class Startup
    {
        private readonly IConfigurationRoot _builder;
        public Startup(IApplicationEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            _builder = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt=> {
                    // deals with javascript lowercase and c# uppercase property conventions when posting
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddEntityFramework()
                .AddNpgsql()
                .AddDbContext<SensorNetContext>();
#if DEBUG
            services.AddTransient<SeedNetwork>();
#endif
            services.AddScoped(provider=>  _builder);
            services.AddScoped<ISensorNetRepository, SensorNetRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#if DEBUG
        public void Configure(IApplicationBuilder app, SeedNetwork seed)
        {
            ConfigApp(app);
            seed.ensureSeedData();

        }
#elif RELEASE
        public void Configure(IApplicationBuilder app)
        {
            ConfigApp(app);
        }
#endif
        private void ConfigApp(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = AppController.C, action = AppController.AHome });
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
