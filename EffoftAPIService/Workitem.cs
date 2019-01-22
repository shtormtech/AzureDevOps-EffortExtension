using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EffoftAPIService
{
    public class WorkItem
    {
        [JsonProperty("id")]
        public Int32 ID { get; set; }
        [JsonProperty("fields")]
        public Fields fields { get; set; }
        [JsonProperty("relations")]
        public List<RelationsItem> relations { get; set; }
        public List<WorkItem> ChildWorkItems;
        public List<Effort> Efforts;
        public override string ToString() => $"(#{this.ID}){this.fields}";
    }
    public class Fields {
        [JsonProperty("System.Title")]
        string Title { get; set; }
        public override string ToString() => $"{this.Title}";
    }

    public class RelationsItem
    {
        [JsonProperty("rel")]
        public string rel { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
    }

}
