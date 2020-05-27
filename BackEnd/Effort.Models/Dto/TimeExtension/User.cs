using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.Models.Dto.TimeExtension
{
    public class User
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }

        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public ActivityType activity { get; set; }
        public int duration { get; set; }
    }
}
