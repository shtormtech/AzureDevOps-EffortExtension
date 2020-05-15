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
    }

    public class TfsWorkItem
    {
        public Int32 ID { get; set; }
        public String name { get; set; }
        public String Pace { get; set; }
        public IEnumerable<TfsWorkItem> ChildWorkItems;
        public IEnumerable<TfsWorkItemEffort> Efforts;
    }

    public class TfsUser
    {   
        public Int32 userid { get; set; }
        public String username { get; set; }
        public String userlogin { get; set; }
        public Int32 effortminute { get; set; }
    }
}