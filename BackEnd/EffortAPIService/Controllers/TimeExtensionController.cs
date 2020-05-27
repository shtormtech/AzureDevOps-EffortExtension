using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureDevOpsServices.interfaces;
using Effort.DB.Layer.Interfaces;
using EffortAPIService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using extension = Effort.Models.Dto.TimeExtension;

namespace EffortAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeExtensionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITimeExtensionService _timeExtensionService;

        public TimeExtensionController(IConfiguration config, ITimeExtensionService timeExtensionService)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _timeExtensionService = timeExtensionService ?? throw new ArgumentNullException(nameof(timeExtensionService));
        }

        [HttpGet("{selfId}/WorkItems")]
        public async Task<ActionResult<List<extension.WorkItem>>> GetWorkItems(int selfId)
        {
            return await _timeExtensionService.GetWorkItems(selfId);
        }

        [HttpGet("{selfId}/Users")]
        public async Task<ActionResult<List<extension.User>>> GetUsers(int selfId)
        {
            return Ok(); //await _azureDevOpsService.GetChildWorkItems(project, selfId);
        }

        [HttpGet("{selfId}/Activities")]
        public async Task<ActionResult<List<extension.Activities>>> GetActivities(int selfId)
        {
            return Ok(); //await _azureDevOpsService.GetChildWorkItems(project, selfId);
        }

    }
}