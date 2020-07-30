using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.Models.Dto
{
    public class TimesheetDto
    {
        public DateTime Date { get; set; }
        public int ActivityTypeId { get; set; }
        public String UserUniqueName { get; set; }
        public int WorkItemId { get; set; }
        public int Duration { get; set; }
        public String Comment { get; set; }
    }
}
