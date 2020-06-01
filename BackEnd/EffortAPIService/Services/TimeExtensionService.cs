using AzureDevOpsServices.interfaces;
using Effort.DB.Layer.Interfaces;
using extension = Effort.Models.Dto.TimeExtension;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Effort.Models.Requests.Extension;

namespace EffortAPIService.Services
{
    public class TimeExtensionService : ITimeExtensionService
    {   
        private readonly IAzureDevOpsService _azureDevOpsService;
        private readonly ITimesheetRepository _timesheetRepository;
        public TimeExtensionService(IAzureDevOpsService azureDevOpsService, ITimesheetRepository timesheetRepository)
        {
            _azureDevOpsService = azureDevOpsService ?? throw new ArgumentNullException();
            _timesheetRepository = timesheetRepository ?? throw new ArgumentNullException();
        }

        public Task<List<extension.Activities>> GetActivities(ActivityRequest req, int selfId)
        {
            throw new NotImplementedException();
        }

        public Task<List<extension.User>> GetUsers(UserRequest req, int selfId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<extension.WorkItem>> GetWorkItems(WiRequest req, int selfId)
        {
            var res= new List<extension.WorkItem>();
            //TODO: Проект убрать после отладки
            var workItems = await _azureDevOpsService.GetChildWorkItems(req.Project ?? "ShtormDemoProject(Agile)", selfId);

            int[] ids = workItems.Select(x => x.Id).Where(x => x!= null).Cast<int>().ToArray();
            var timesheets = await _timesheetRepository.GetTimesheets(ids);

            workItems.ForEach(x =>
                {
                    var duration = timesheets.Where(y => y.WorkItemId == x.Id).Sum(z => z.Duration);
                    if (duration > 0)
                    {
                        res.Add(new extension.WorkItem(x, duration));
                    }
                }
            );

            return res;
        }
    }
}
