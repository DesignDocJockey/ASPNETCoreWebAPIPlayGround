using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Contexts;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }
        public IHostingEnvironment HostingEnvironment { get; }

        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddEnvironmentVariables();
                                
            Configuration = builder.Build();
            HostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add options here for content negotiation
            services.AddMvc()
                    .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

#if DEBUG
            //AddTransient() objects are created for each request, perfect for light weight and stateless services
            services.AddTransient<INotificationService, StubNotificationService>();
#else
            services.AddTransient<INotificationService, NotificationService>();
#endif
            //AddScoped() objects are created once within the scope of the request and shared across the request session
            //services.AddScoped()

            //AddSingleton() objects are created once within the scope of the application's lifetime and shared across the entire application pool
            //services.AddSingleton()
            var connectionString = Startup.Configuration["ConnectionString:SneakersDbConnectionString"];
            services.AddDbContext<SneakersDbContext>(options =>
                        options.UseSqlServer(connectionString)
                   );
        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        // Define Middleware componets in this method
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug(LogLevel.Information);

            if (env.IsDevelopment())
            {
                //this is a developer exception page Middleware component
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //use Exception Handler Middleware component
                app.UseExceptionHandler();
            }

            //this middleware returns status code in text from browser requests
            app.UseStatusCodePages();

            //this is the ASP.NET MVC MiddleWare
            app.UseMvc();
        }
    }
}
