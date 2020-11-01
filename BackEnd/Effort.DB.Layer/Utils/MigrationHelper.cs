using System;
using System.Threading;
using System.Threading.Tasks;
using Effort.DB.Layer.Context;
using Microsoft.EntityFrameworkCore;

namespace Effort.DB.Layer.Utils
{
    public class MigrationHelper 
    {
        protected string ConnectionString { get; }
        private IEffortDbContextFactory ContextFactory { get; }
        public MigrationHelper(string connectionString, IEffortDbContextFactory contextFactory)
        {
            ConnectionString = connectionString;
            ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }
        public async Task MigrateAsync(CancellationToken ct = default)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                await context.Database.MigrateAsync(ct);
            }
        }
    }
}
