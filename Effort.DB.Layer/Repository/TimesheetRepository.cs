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
        public async Task<Timesheet> GetTimesheet(long id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Timesheet.SingleAsync(b => b.Id == id);
            }
        }
        public async Task<List<Timesheet>> GetTimesheets(long[] WorkItemIds = null, string UserId = "", bool isActual = true)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var ts = from timesheet in context.Timesheet
                         where ( (WorkItemIds == null) || (WorkItemIds.Contains(timesheet.WorkItemId)) 
                              && ((UserId == "") || (timesheet.UserId == UserId))
                              && ((!isActual) || (timesheet.Deleted == !isActual))
                                )
                         select timesheet;
                return await ts.ToListAsync();
            }
        }
        public async Task AddTimesheets(List<Timesheet> Timesheets)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Timesheet.AddRange(Timesheets);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Timesheet>> EditTimesheets(List<Timesheet> Timesheets)
        {
            throw new NotImplementedException();
            /*using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {

            }*/
        }
        public async Task EditTimesheet(long id, Timesheet timesheet)
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
        public async Task<Timesheet> DeleteTimesheet(long id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var timesheet = await context.Timesheet.FirstAsync(x => x.Id == id && x.Deleted == false);
                if (timesheet == null)
                {
                    return null;
                }

                timesheet.Deleted = true;
                await context.SaveChangesAsync();

                return timesheet;


            }
        }
        public bool TimesheetExists(long id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return context.Timesheet.Any(e => e.Id == id);
            }
        }
    }
}
