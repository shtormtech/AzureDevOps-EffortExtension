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
        private readonly IActivityTypeRepository _activityTypeRepository;

        public TimeExtensionService(
            IAzureDevOpsService azureDevOpsService, 
            ITimesheetRepository timesheetRepository, 
            IActivityTypeRepository activityTypeRepository)
        {
            _azureDevOpsService = azureDevOpsService ?? throw new ArgumentNullException(nameof(azureDevOpsService));
            _timesheetRepository = timesheetRepository ?? throw new ArgumentNullException(nameof(timesheetRepository));
            _activityTypeRepository = activityTypeRepository ?? throw new ArgumentNullException(nameof(activityTypeRepository));
        }

        public async Task<List<extension.Activities>> GetActivities(ActivityRequest req, int selfId)
        {
            var res = new List<extension.Activities>();
            //TODO: Проект убрать после отладки
            var workItems = await _azureDevOpsService.GetChildWorkItems(req.Project ?? "ShtormDemoProject(Agile)", selfId);
            int[] wiIds = workItems.Select(x => x.Id).Where(x => x != null).Cast<int>().ToArray();            
            var timesheets = await _timesheetRepository.GetTimesheets(wiIds);
            var actIds = timesheets.Select(ts => ts.ActivityTypeId).Distinct().ToArray();
            var activities = await _activityTypeRepository.GetActivityTypes(actIds);

            activities.ForEach(x =>
                {
                    var duration = timesheets.Where(y => y.ActivityTypeId == x.Id).Sum(z => z.Duration);
                    if (duration > 0)
                    {
                        res.Add(new extension.Activities(x, duration));
                    }
                }
            );

            return res;
        }

        public async Task<List<extension.User>> GetUsers(UserRequest req, int selfId)
        {
            var res = new List<extension.User>();

            var u = await _azureDevOpsService.GetUser("");

            var workItems = await _azureDevOpsService.GetChildWorkItems(req.Project ?? "ShtormDemoProject(Agile)", selfId);
            int[] wiIds = workItems.Select(x => x.Id).Where(x => x != null).Cast<int>().ToArray();
            var timesheets = await _timesheetRepository.GetTimesheets(wiIds);
            var actIds = timesheets.Select(ts => ts.ActivityTypeId).Distinct().ToArray();
            var activities = await _activityTypeRepository.GetActivityTypes(actIds);



            return res;
        }

        public async Task<List<extension.WorkItem>> GetWorkItems(WiRequest req, int selfId)
        {
            var res= new List<extension.WorkItem>();
            //TODO: Проект убрать после отладки
            var workItems = await _azureDevOpsService.GetChildWorkItems(req.Project ?? "ShtormDemoProject(Agile)", selfId);

            int[] wiIds = workItems.Select(x => x.Id).Where(x => x!= null).Cast<int>().ToArray();
            var timesheets = await _timesheetRepository.GetTimesheets(wiIds);

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
