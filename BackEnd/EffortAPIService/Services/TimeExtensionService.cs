using AzureDevOpsServices.interfaces;
using Effort.DB.Layer.Interfaces;
using extension = Effort.Models.Dto.TimeExtension;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Effort.Models.Requests.Extension;
using EffortAPIService.Extensions;

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
            //TODO: Проект убрать после отладки            
            var workItems = await _azureDevOpsService.GetChildWorkItems(req.Project ?? "ShtormDemoProject(Agile)", selfId);
            int[] wiIds = workItems.Select(x => x.Id).Where(x => x != null).Cast<int>().ToArray();            
            var timesheets = await _timesheetRepository.GetTimesheets(wiIds);

            return timesheets.GroupingActivitiesDuration().ToList();
        }

        public async Task<List<extension.User>> GetUsers(UserRequest req, int selfId)
        {
            //TODO: Проект убрать после отладки 
            var res = new List<extension.User>();

            var workItems = await _azureDevOpsService.GetChildWorkItems(req.Project ?? "ShtormDemoProject(Agile)", selfId);
            int[] wiIds = workItems.Select(x => x.Id).Where(x => x != null).Cast<int>().ToArray();
            var timesheets = await _timesheetRepository.GetTimesheets(wiIds);

            List<Guid> uIds = timesheets
                                .Where(x => Guid.TryParse(x.UserUniqueName, out var i))
                                .Select(x => Guid.Parse(x.UserUniqueName))
                                .Distinct()
                                .ToList();

            var users = await _azureDevOpsService.GetIdentitiesByIds(uIds);

            users.ForEach(user => res.Add(new extension.User(
                _azureDevOpsService.GetServerUrl(),
                user,
                timesheets.Where(timesheet => timesheet.UserUniqueName == user.Id.ToString())
                    .GroupingActivitiesDuration()
                    .ToList()
                ))
            );

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
