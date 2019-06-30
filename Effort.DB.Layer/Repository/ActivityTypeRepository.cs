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
    public class ActivityTypeRepository : BaseRepository, IActivityTypeRepository
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

        public async Task EditActivityType(long id, ActivityType activityType)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {

                context.Entry(activityType).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!TimesheetExists(id))
                    {
                        throw new KeyNotFoundException(e.Message);
                    }
                    else
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        public bool TimesheetExists(long id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return context.ActivityType.Any(e => e.Id == id);
            }
        }
    }
}
