using Effort.DB.Layer.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Effort.DB.Layer.Utils
{
    class DesignEffortDBContextFactory
    {
        /// <summary>
        /// Класс позволяющий выполнить:
        /// - Add-Migration InitialCreate
        /// - Update-Database
        /// без запуска приложения, в DesignTime
        /// </summary>
        public class DesignTimeTextTemplateDBContextFactory :
        IDesignTimeDbContextFactory<EffortDbContext>
        {
            public EffortDbContext CreateDbContext(string[] args)
            {
                var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

                var config = builder.Build();
                var connectionString = config.GetConnectionString("DefaultConnection");
                var repositoryFactory = new EffortDbContextFactory();

                return repositoryFactory.CreateDbContext(connectionString);
            }
        }
    }
}
