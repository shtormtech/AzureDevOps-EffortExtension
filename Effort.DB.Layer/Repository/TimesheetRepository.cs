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
        public async Task<Timesheet> GetTimesheet(long Id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Timesheet.SingleAsync(b => b.Id == Id);
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
        public async Task AddTimesheet(List<Timesheet> Timesheets)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Timesheet.AddRange(Timesheets);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTimesheet(long Id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var timesheet = context.Timesheet.First(x => x.Id == Id);
                timesheet.Deleted = true;
                await context.SaveChangesAsync();
            }
        }
    }
}
