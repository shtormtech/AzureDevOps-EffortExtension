using Effort.DB.Layer.Context;
using Effort.DB.Layer.Interfaces;
using Effort.DB.Layer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace EffortAPIService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").AddEnvironmentVariables();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var defConStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IEffortDbContextFactory, EffortDbContextFactory>();
            services.AddScoped<IActivityTypeRepository>(provider => new ActivityTypeRepository(defConStr, provider.GetService<IEffortDbContextFactory>()));
            services.AddScoped<ITimesheetRepository>(provider => new TimesheetRepository(defConStr, provider.GetService<IEffortDbContextFactory>()));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0", new Info { Title = "Effort API", Version = "v0" });
                // Set the comments path for the Swagger JSON and UI.
                // TODO: Проверит существование файла
                var xmlFile = $"EffortAPIService.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            // ************* Use swagger **************************************
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0/swagger.json", "TextTemplate API V0");
                c.RoutePrefix = string.Empty;
            });
            // TODO: Позже убрать
            app.UseCors("MyPolicy");

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
