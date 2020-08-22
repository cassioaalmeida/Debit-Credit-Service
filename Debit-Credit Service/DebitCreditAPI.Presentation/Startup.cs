using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DebitCreditAPI.Infra.CrossCutting.IOC;
using DebitCreditAPI.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DebitCreditAPI.Presentation
{
    public class Startup
    {
        // IContainer instance in the Startup class 
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["SqliteConnection:SqliteConnectionString"];
            services.AddDbContext<SqliteContext>(options =>
                options.UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutofac();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Debit Credit API Implementation",
                    Description = "Available Web APIs"
                });
                
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ModuleIOC());
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleIOC());
        }
    }
}
