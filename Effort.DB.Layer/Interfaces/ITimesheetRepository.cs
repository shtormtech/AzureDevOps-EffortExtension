using Effort.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Effort.DB.Layer.Interfaces
{
    public interface ITimesheetRepository
    {
        Task<List<Timesheet>> GetTimesheets(long[] WorkItemIds = null, String UserId = "", bool isActual = true);
        Task<Timesheet> GetTimesheet(long id);
        Task<List<Timesheet>> EditTimesheets(List<Timesheet> Timesheets);
        Task EditTimesheet(long id, Timesheet timesheet);
        Task AddTimesheets(List<Timesheet> Timesheets);
        Task<Timesheet> DeleteTimesheet(long id);
        bool TimesheetExists(long id);
    }
}