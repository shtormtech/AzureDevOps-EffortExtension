using System;
using System.Collections.Generic;

namespace effort_extension.tfs
{
    public class TfsWorkItemEffort
    {
        public Int32 ID { get; set; }
        public Int32 WorkItemId { get; set; }
        public String UserId { get; set; } // userLogin
        public int Minute { get; set; }
        public String Comment { get; set; }
        public Int32 ActivityTypeId { get; set; }

    }

    public class TfsWorkItem
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public IEnumerable<TfsWorkItem> ChildWorkItems;
        public IEnumerable<TfsWorkItemEffort> Efforts;
    }

    public class TfsUser
    {
        public Guid UserId { get; set; }
        public String uniqueName { get; set; }
        public String displayName { get; set; }
        public String imageUrl { get; set; }
    }
}