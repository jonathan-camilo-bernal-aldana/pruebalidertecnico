using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Core.Implementation;
using Application.Core.Interfaces;
using Infrastructure.Core.Implementation.Context;
using Infrastructure.Core.Interfaces.IContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Services.Core.Implementation;
using Services.Core.Interfaces;
using Utilities.Core.Implementation.ActiveMq;
using Utilities.Core.Interfaces.IActiveMq;

namespace DistributedServices.Core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) {
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            builder.AddEnvironmentVariables();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddControllers();

            //Configure MongoDB
            services.Configure<MongoDataBaseSettings>(Configuration.GetSection("OrdersStoreMongoDb"));


            services.AddSingleton<IMongoDataBaseSettings>(sp => sp.GetRequiredService<IOptions<MongoDataBaseSettings>>().Value);

            //Application
            services.AddScoped<IOrderManagementApplication, OrderManagementApplication>();
            services.AddScoped<IQueueManager, QueueManager>();

            //Infraestructure
            services.AddTransient<IContextDb, ContextDb>();

            //Services
            services.AddTransient<IServiceSap, ServiceSap>();

            //Utilities
            services.AddScoped<IActiveMq, ActiveMq>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IQueueManager queueManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            queueManager.StartEnqueue();
        }
    }
}
