using Effort.DB.Layer.Context;
using Effort.DB.Layer.Interfaces;
using Effort.DB.Layer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace EffortAPIService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var Config = new ConfigurationBuilder()
                .SetBasePath(env?.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
            Configuration = Config.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var defConStr = Configuration.GetConnectionString("DefaultConnection");

            services.AddControllers();
            services.AddHealthChecks();
            services.AddScoped<IEffortDbContextFactory, EffortDbContextFactory>();
            services.AddScoped<IActivityTypeRepository>(provider => new ActivityTypeRepository(defConStr, provider.GetService<IEffortDbContextFactory>()));
            services.AddScoped<ITimesheetRepository>(provider => new TimesheetRepository(defConStr, provider.GetService<IEffortDbContextFactory>()));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0", new OpenApiInfo { Title = "Effort API", Version = "v0" });
                // Set the comments path for the Swagger JSON and UI.
                c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}EffortAPIService.xml");
            });

            // TODO: Позже убрать
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //TODO: Enable production exception handling (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling)
                app.UseExceptionHandler("/Error");

                //app.UseHsts();
            }

            // ************* Use swagger **************************************
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0/swagger.json", "Effort API V0");
                c.RoutePrefix = string.Empty;
            });
            // TODO: Позже убрать
            app.UseCors("MyPolicy");

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHealthChecks("/health");
        }
    }
}
