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
        public async Task<ActivityType> GetActivityType(long activityTypeId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.ActivityType.SingleAsync(b => b.Id == activityTypeId);
            }
        }
        public async Task<List<ActivityType>> GetActivityTypes(int[] activityTypeIds = null, bool isDeleted = false)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var at = from activityType in context.ActivityType
                         where (
                              ((activityTypeIds == null) || (activityTypeIds.Contains(activityType.Id)))
                            && (activityType.IsDeleted == isDeleted)
                         )
                         select activityType;
                return await at.ToListAsync(); 
            }
        }

        public async Task<ActivityType> AddActivityType(ActivityType activityType)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.ActivityType.Add(activityType);
                var id = await context.SaveChangesAsync();
                activityType.Id = id;
                return activityType;
            }
        }

        public async Task DeleteActivityType(long activityTypeId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var activitType = await context.ActivityType.FindAsync(activityTypeId);
                if (activitType == null)
                {
                    throw new KeyNotFoundException("Запись не найдена");
                }
                if (activitType.IsDeleted)
                {
                    throw new ArgumentException("Тип активности уже удален");
                }

                activitType.IsDeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateActivityType(ActivityType activityType)
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
                    if (!ActivityTypeExists(activityType.Id))
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

        public bool ActivityTypeExists(long activityTypeId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return context.ActivityType.Any(e => e.Id == activityTypeId);
            }
        }
    }
}
