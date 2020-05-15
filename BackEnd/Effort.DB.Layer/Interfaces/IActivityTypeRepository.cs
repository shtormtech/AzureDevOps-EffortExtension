using Effort.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Effort.DB.Layer.Interfaces
{
    public interface IActivityTypeRepository
    {
        Task<List<ActivityType>> GetActivityTypes(bool isDeleted = false);
        Task<ActivityType> GetActivityType(long activityTypeId);
        Task UpdateActivityType(ActivityType activityType);
        Task<ActivityType> AddActivityType(ActivityType activityType);
        Task DeleteActivityType(long activityTypeId);
        bool ActivityTypeExists(long activityTypeId);
    }
}
