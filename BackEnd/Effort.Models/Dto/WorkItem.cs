using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.Models.Dto
{
    public class WorkItem
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string WorkItemType { get; set; }
        public WorkItem[] Cilds { get; set; }


    }
}
