using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.Models.Dto.TimeExtension
{
    public class Activities
    {
        public Activities(ActivityType activityType, int duration)
        {
            ActivityType = activityType;
            Duration = duration;
        }

        public ActivityType ActivityType { get; set; }
        public int Duration { get; set; }
    }
}
