using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsServices.interfaces
{
    public interface IAzureDevOpsService
    {
        Task<List<WorkItem>> GetChildWorkItems(string projectId, int selfId);
    }
}
