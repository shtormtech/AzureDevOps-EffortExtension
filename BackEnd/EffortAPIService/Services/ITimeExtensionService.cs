using Effort.Models.Requests.Extension;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using extension = Effort.Models.Dto.TimeExtension;

namespace EffortAPIService.Services
{
    public interface ITimeExtensionService
    {
        Task<List<extension.WorkItem>> GetWorkItems(WiRequest req, int selfId);
        Task<List<extension.User>> GetUsers(UserRequest req, int selfId);
        Task<List<extension.Activities>> GetActivities(ActivityRequest req,  int selfId);
    }
}
