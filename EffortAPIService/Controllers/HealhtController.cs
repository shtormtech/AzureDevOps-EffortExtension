using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EffortAPIService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Метод для проверки состояния сервиса
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "Alive";
        }
    }
}