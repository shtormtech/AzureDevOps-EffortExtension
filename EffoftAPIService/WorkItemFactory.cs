//==============================================================================
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EffoftAPIService
{
    public static class WorkItemFactory
    {        
        public static WorkItem GetWorkItemAndChild(Int32 id)
        {
            string JSONresp = Connectors.tfsConnector.GetWorkItemForIdAsync(id).Result;
           
            if ( !string.IsNullOrEmpty(JSONresp))
            {
                WorkItem a = JsonConvert.DeserializeObject<WorkItem>(JSONresp);

                string respStr = JSONresp; 
                WorkItem item = new WorkItem();
                
                List<string> _ChildWorkItems = new List<string>();
                foreach (RelationsItem relation in a.relations)
                {
                    if (relation.rel == "System.LinkTypes.Hierarchy-Forward")
                    {
                        string str = relation.url;
                        int ch_id = Convert.ToInt32(str.Substring(str.LastIndexOf('/') + 1, str.Length - (str.LastIndexOf('/') + 1)));

                        if (item.ChildWorkItems == null)
                            item.ChildWorkItems = new List<WorkItem>();

                        WorkItem newChild = GetWorkItemAndChild(ch_id);
                        if (newChild != null)
                            item.ChildWorkItems.Add(newChild);
                    }
                }
                return item;
            }
            return null;
        }
    }
}
