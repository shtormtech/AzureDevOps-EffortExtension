using System.Collections.Generic;
using System.Linq;
using Effort.Models.Dto.TimeExtension;
using Effort.Models;

namespace EffortAPIService.Extensions
{
    public static class TimeSheetExtension
    {
        public static IEnumerable<Activities> GroupingActivitiesDuration( this IEnumerable<Timesheet> timesheets) {
            return timesheets
                    .GroupBy(
                        timesheet => timesheet.ActivityType,
                        timesheet => timesheet.Duration,
                        (activity, duration) => new
                        {
                            resActivity = activity,
                            sumDuration = duration.Sum()
                        })
                    .Select(groupingActivity =>
                        new Activities(groupingActivity.resActivity, groupingActivity.sumDuration));
        }
    }
}
