using Effort.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Effort.DB.Layer.Interfaces
{
    public interface IActivityTypeRepository
    {
        Task<List<ActivityType>> GetActivityTypes(bool isActual = true);
        Task<ActivityType> GetActivityType(long ActivityTypeId);
        Task EditActivityType(long id, ActivityType activityType);
        Task AddActivityType(ActivityType item);
        Task DeleteActivityType(long ActivityTypeId);
        bool TimesheetExists(long id);
    }
}
