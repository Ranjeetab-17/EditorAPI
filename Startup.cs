using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

////using Microsoft.Extensions.Logging;
////using Serilog;

namespace EditorAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        ///private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }


        public IConfiguration Configuration { get; }

        private ILogger<Startup> _logger;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var appname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: "default",
                     template: "api/[controller]",
                     defaults: "{controller=Editor}"
                    );
            });

            app.UseStaticFiles();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowCredentials();
            });

            Log.Logger =
             new LoggerConfiguration()
               .MinimumLevel.Verbose()
               .WriteTo.Console()
               .WriteTo.RollingFile(@"Logs\" + appname + "-{Date}.txt")
               .CreateLogger();

            loggerFactory.AddSerilog();



            ////loggerFactory.AddConsole(Configuration.GetSection("Logging")); //log levels set in your configuration
            ////loggerFactory.AddDebug(); //does all log levels
            ////loggerFactory.AddFile("logFileFromHelper.log");

            ////app.Run(async (context) =>
            ////{
            ////    await context.Response.WriteAsync("Hello World!");
            ////});
        }
    }
}
