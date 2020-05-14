using Effort.DB.Layer.Context;
using Effort.DB.Layer.Interfaces;
using Effort.Models;
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
                return await context.Timesheet.FindAsync(timesheetId);
            }
        }
        public async Task<List<Timesheet>> GetTimesheets(long[] WorkItemIds = null, string UserId = "", bool isDeleted = false)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var ts = from timesheet in context.Timesheet
                         where ( (WorkItemIds == null) || (WorkItemIds.Contains(timesheet.WorkItemId)) 
                              && ((UserId == "") || (timesheet.UserId == UserId))
                              && (timesheet.Deleted == isDeleted)
                              )
                         select timesheet;
                return await ts.ToListAsync();
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

        public async Task<Timesheet> AddTimesheet(Timesheet timesheet)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Timesheet.Add(timesheet);
                long id = await context.SaveChangesAsync();
                timesheet.Id = id;

                return timesheet;
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
                if (timesheet.Deleted)
                {
                    throw new ArgumentException("Запись уже удалена");
                }

                timesheet.Deleted = true;
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
