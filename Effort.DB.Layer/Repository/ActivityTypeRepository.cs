using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort.DB.Layer.Context;
using Effort.DB.Layer.Interfaces;
using Effort.Models;
using Microsoft.EntityFrameworkCore;

namespace Effort.DB.Layer.Repository
{
    class ActivityTypeRepository : BaseRepository, IActivityTypeRepository
    {
        public ActivityTypeRepository(string connectionString, IEffortDbContextFactory contextFactory) : base(connectionString, contextFactory)
        {
        }
        public async Task<ActivityType> GetActivityType(long ActivityTypeId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.ActivityType.SingleAsync(b => b.Id == ActivityTypeId);
            }
        }
        public async Task<List<ActivityType>> GetActivityTypes(bool isActual = true)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.ActivityType.Where(x => x.Deleted == !isActual).ToListAsync();
            }
        }

        public async Task AddActivityType(ActivityType item)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.ActivityType.Add(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteActivityType(long ActivityTypeId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var activity = context.ActivityType.First(x => x.Id == ActivityTypeId);
                activity.Deleted = true;
                await context.SaveChangesAsync();
            }
        }
    }
}
