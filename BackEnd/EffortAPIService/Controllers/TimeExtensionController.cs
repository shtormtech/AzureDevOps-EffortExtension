﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureDevOpsServices.interfaces;
using Effort.DB.Layer.Interfaces;
using Effort.Models.Requests.Extension;

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
        public async Task<ActionResult<List<extension.WorkItem>>> GetWorkItems(int selfId, [FromQuery] WiRequest req)
        {
            return await _timeExtensionService.GetWorkItems(req, selfId);
        }

        [HttpGet("{selfId}/Users")]
        public async Task<ActionResult<List<extension.User>>> GetUsers(int selfId, [FromQuery] UserRequest req)
        {
            return await _timeExtensionService.GetUsers(req, selfId);
        }

        [HttpGet("{selfId}/Activities")]
        public async Task<ActionResult<List<extension.Activities>>> GetActivities(int selfId, [FromQuery] ActivityRequest req)
        {
            return await _timeExtensionService.GetActivities(req, selfId);
        }

    }
}