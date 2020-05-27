using Effort.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Effort.DB.Layer.Interfaces
{
    public interface ITimesheetRepository
    {
        Task<List<Timesheet>> GetTimesheets(int[] WorkItemIds = null, String UserId = "", bool isDeleted = false);
        Task<Timesheet> GetTimesheet(long timesheetId);
        Task UpdateTimesheets(List<Timesheet> timesheets);
        Task UpdateTimesheet(Timesheet timesheet);
        Task<Timesheet> AddTimesheet(Timesheet timesheet);
        Task<List<Timesheet>> AddTimesheets(List<Timesheet> timesheets);
        Task DeleteTimesheet(long timesheetId);
        bool TimesheetExists(long timesheetId);
    }
}