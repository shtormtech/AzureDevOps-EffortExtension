using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureDevOpsServices.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace EffortAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IAzureDevOpsService _azureDevOpsService;

        public WorkItemsController(IConfiguration config, IAzureDevOpsService azureDevOpsService)
        {
            _config = config;
            _azureDevOpsService = azureDevOpsService;
        }

        [HttpGet("{selfId}")]
        public async Task<ActionResult<List<WorkItem>>> Get(int selfId)
        {
            return await _azureDevOpsService.GetChildWorkItems("OKMF", 171349);
        }

    }
}