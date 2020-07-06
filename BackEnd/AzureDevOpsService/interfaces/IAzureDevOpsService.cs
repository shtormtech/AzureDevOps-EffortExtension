using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Identity;
using Microsoft.VisualStudio.Services.WebApi;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using efort = Effort.Models.Dto.TimeExtension;

namespace AzureDevOpsServices.interfaces
{
    public interface IAzureDevOpsService
    {
        Task<List<WorkItem>> GetChildWorkItems(string projectId, int selfId, bool isRecursive = false);
        Task<IdentitiesCollection> GetUser(string UniqueName);
        Task<IdentitiesCollection> GetIdentitiesByIds(List<Guid> ids);
        Task<List<efort.User>> GetUserByIds(List<Guid> ids);
    }
}
