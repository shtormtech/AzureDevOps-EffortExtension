using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.DB.Layer.Context
{
    public class EffortDbContextFactory : IEffortDbContextFactory
    {
        public EffortDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EffortDbContext>();
            optionsBuilder.UseNpgsql(connectionString,
                        x => x.MigrationsHistoryTable(
                            HistoryRepository.DefaultTableName,
                            "effort"));

            return new EffortDbContext(optionsBuilder.Options);
        }
    }
}
