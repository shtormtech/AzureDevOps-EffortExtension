using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EffoftAPIService
{
    public class Effort
    {
        public Int32 ID { get; set; }
        public Int32 WorkItemId { get; set; }
        public String UserId { get; set; } // userLogin
        public int Minute { get; set; }
        public String Comment { get; set; }
        public Int32 ActivityTypeId { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
