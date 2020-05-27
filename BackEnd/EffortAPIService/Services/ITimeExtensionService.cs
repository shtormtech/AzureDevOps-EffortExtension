using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using extension = Effort.Models.Dto.TimeExtension;

namespace EffortAPIService.Services
{
    public interface ITimeExtensionService
    {
        Task<List<extension.WorkItem>> GetWorkItems(int selfId);
        Task<List<extension.User>> GetUsers(int selfId);
        Task<List<extension.Activities>> GetActivities(int selfId);
    }
}
