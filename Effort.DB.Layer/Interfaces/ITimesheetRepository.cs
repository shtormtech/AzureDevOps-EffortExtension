using Effort.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Effort.DB.Layer.Interfaces
{
    interface ITimesheetRepository
    {
        Task<List<Timesheet>> GetTimesheets(long[] WorkItemIds = null, String UserId = "", bool isActual = true);
        Task<Timesheet> GetTimesheet(long Id);
        Task AddTimesheet(List<Timesheet> Timesheets);
        Task DeleteTimesheet(long Id);
    }
}