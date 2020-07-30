using Effort.DB.Layer.Context;
using Effort.DB.Layer.Interfaces;
using Effort.Models;
using Effort.Models.Dto;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effort.DB.Layer.Repository
{
    public class TimesheetRepository : BaseRepository, ITimesheetRepository
    {
        public TimesheetRepository(string connectionString, IEffortDbContextFactory contextFactory) : base(connectionString, contextFactory)
        {

        }
        public async Task<Timesheet> GetTimesheet(long timesheetId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Timesheet
                                .Include(t => t.ActivityType)
                                .Where(ts => ts.Id == timesheetId)
                                .FirstOrDefaultAsync();
            }
        }
        public async Task<List<Timesheet>> GetTimesheets(int[] WorkItemIds = null, string UserId = "", bool isDeleted = false)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var ts = from timesheet in context.Timesheet
                         where ( 
                              ((WorkItemIds == null) || (WorkItemIds.Contains(timesheet.WorkItemId)))
                              && ((UserId == "") || (timesheet.UserUniqueName == UserId))
                              && (timesheet.IsDeleted == isDeleted)
                              )
                         select timesheet;
                return await ts.Include(c => c.ActivityType).ToListAsync();
            }
        }
        public async Task<List<Timesheet>> AddTimesheets(List<Timesheet> timesheets)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Timesheet.AddRange(timesheets);
                await context.SaveChangesAsync();
                return timesheets;
            }
        }

        public async Task<Timesheet> AddTimesheet(TimesheetDto timesheet)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var ts = new Timesheet
                {
                    ActivityTypeId = timesheet.ActivityTypeId,
                    Date = timesheet.Date,
                    WorkItemId = timesheet.WorkItemId,
                    Duration = timesheet.Duration,
                    UserUniqueName = timesheet.UserUniqueName,
                    Comment = timesheet.Comment
                };

                context.Timesheet.Add(ts);
                context.SaveChanges();
                
                return ts;
            }
        }

        public async Task UpdateTimesheets(List<Timesheet> timesheets)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateTimesheet(Timesheet timesheet)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {

                context.Entry(timesheet).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!TimesheetExists(timesheet.Id))
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
        public async Task DeleteTimesheet(long timesheetId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var timesheet = await context.Timesheet.FindAsync(timesheetId);
                
                if (timesheet == null)
                {
                    throw new KeyNotFoundException("Запись не найдена");
                }
                if (timesheet.IsDeleted)
                {
                    throw new ArgumentException("Запись уже удалена");
                }

                timesheet.IsDeleted = true;
                await context.SaveChangesAsync();
            }
        }
        public bool TimesheetExists(long timesheetId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return context.Timesheet.Any(e => e.Id == timesheetId);
            }
        }
    }
}
