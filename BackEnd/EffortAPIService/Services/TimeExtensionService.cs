using AzureDevOpsServices.interfaces;
using Effort.DB.Layer.Interfaces;
using extension = Effort.Models.Dto.TimeExtension;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EffortAPIService.Services
{
    public class TimeExtensionService : ITimeExtensionService
    {
        const string project = "OKMF";
        private readonly IAzureDevOpsService _azureDevOpsService;
        private readonly ITimesheetRepository _timesheetRepository;
        public TimeExtensionService(IAzureDevOpsService azureDevOpsService, ITimesheetRepository timesheetRepository)
        {
            _azureDevOpsService = azureDevOpsService ?? throw new ArgumentNullException();
            _timesheetRepository = timesheetRepository ?? throw new ArgumentNullException();
        }

        public Task<List<extension.Activities>> GetActivities(int selfId)
        {
            throw new NotImplementedException();
        }

        public Task<List<extension.User>> GetUsers(int selfId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<extension.WorkItem>> GetWorkItems(int selfId)
        {
            List<extension.WorkItem> res= new List<extension.WorkItem>();
            var workItems = await _azureDevOpsService.GetChildWorkItems(project, selfId);

            int[] ids = workItems.Select(x => x.Id).Where(x => x!= null).Cast<int>().ToArray();
            workItems.ForEach(x => res.Add(new extension.WorkItem(x)));

            var timesheets = await _timesheetRepository.GetTimesheets(ids);

            throw new NotImplementedException();
        }
    }
}
