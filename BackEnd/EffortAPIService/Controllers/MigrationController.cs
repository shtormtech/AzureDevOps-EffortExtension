using System;
using System.Threading;
using System.Threading.Tasks;
using Effort.DB.Layer.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EffortAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private MigrationHelper MigrationHelper { get; }
        public MigrationController(MigrationHelper migrationHelper)
        {
            MigrationHelper = migrationHelper ?? throw new ArgumentNullException(nameof(migrationHelper));
        }
        /// <summary>
        /// Migrate
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<string>> Get(CancellationToken ct)
        {
            try
            {
                await MigrationHelper.MigrateAsync(ct);
                return Ok("Migration complete");
            }
            catch (Exception e)
            {
                return BadRequest(JsonConvert.SerializeObject($"migrations failed {e}"));
            }
        }
    }
}
