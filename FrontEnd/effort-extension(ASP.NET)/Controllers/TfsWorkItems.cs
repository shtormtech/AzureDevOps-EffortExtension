using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
//using effort_extension.tfs;
using effort_extension.tfs_obj;
using effort_extension.TfsAPI;
using Microsoft.AspNetCore.Mvc;

namespace effort_extension.Controllers
{
    [Route("api/[controller]")]
    public class TfsWorkItemsController : Controller
    {
        [HttpGet("[action]")]
        public TfsWorkItem GetTfsWorkItem(Int32 witid)
        {
            return  new TfsWorkItem
            {
                ID = witid,
                Efforts = Enumerable.Range(1, 5).Select(index2 => GetWorkItemEffort(witid))
            };
        }

        [HttpGet("[action]")]
        public IEnumerable<TfsWorkItem> GetTfsChildWorkItems(Int32 witid)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new TfsWorkItem
            {
                ID = witid,
                Efforts = Enumerable.Range(1, 5).Select(index2 => GetWorkItemEffort(witid))
            });
        }            

        [HttpGet("[action]")]
        public IEnumerable<TfsWorkItemEffort> GetTfsWorkItemEfforts(Int32 witid)
        {
            return Enumerable.Range(1, 5).Select(index => GetWorkItemEffort(witid));
        }

        [HttpGet("[action]")]
        public IEnumerable<TfsUser> GetTfsWorkItemUserEffort(Int32 witid)
        {
            return Enumerable.Range(1, 5).Select(index => GetWorkItemUserEffort(witid));
        }

        private TfsWorkItemEffort GetWorkItemEffort(Int32 witid)
        {
            var rng = new Random();
            return new TfsWorkItemEffort()
            {
                ID = rng.Next(0, 100),
                WorkItemId = witid,
                UserId = "UserEmail",
                Minute = rng.Next(0, 480),
                Comment = "Comment"
            };
        }

        private TfsUser GetWorkItemUserEffort(Int32 witid)
        {
            var rng = new Random();
            return new TfsUser()
            {
                UserId = Guid.NewGuid(),
                imageUrl = "UseName",
                displayName = "UserEmail"
            };
        }
    }
}
