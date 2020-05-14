using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Effort.DB.Layer.Interfaces;
using Effort.Models;
using Microsoft.AspNetCore.Mvc;

namespace EffortAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypesController : ControllerBase
    {
        private readonly IActivityTypeRepository _activityTypeRepositiry;
        /// <summary>
        /// Конструктор контроллера активностей
        /// </summary>
        /// <param name="activityTypeRepository"></param>
        public ActivityTypesController(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepositiry = activityTypeRepository;
        }

        /// <summary>
        /// Получить все виды активностей
        /// </summary>
        /// <param name="isDeleted">Показать только актуальные (не удаленные)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ActivityType>>> Get(bool isDeleted = false)
        {
            return await _activityTypeRepositiry.GetActivityTypes(isDeleted);
        }

        /// <summary>
        /// Получить нужный вид активности
        /// </summary>
        /// <param name="id">Идентификатор активности</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ActivityType>> Get(long activityTypeId)
        {
            var activity = await _activityTypeRepositiry.GetActivityType(activityTypeId);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;

        }

        /// <summary>
        /// Добавить новый вид активности
        /// </summary>
        /// <param name="NewActivityType">Новый вид активности</param>
        [HttpPost]
        public async Task<ActionResult<ActivityType>> CreateActivityType([FromBody] ActivityType NewActivityType)
        {
            return await _activityTypeRepositiry.AddActivityType(NewActivityType);
        }

        
        // PUT: api/ActivityType/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivityType(long activityTypeId, [FromBody] ActivityType activityType)
        {
            if ((activityTypeId != activityType.Id) || activityType.Deleted)
            {
                return BadRequest();
            }

            try
            {
                await _activityTypeRepositiry.UpdateActivityType(activityType);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
        

        /// <summary>
        /// Удалить тип активности
        /// </summary>
        /// <param name="id">Идентификатор удаляемого типа активности</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long activityTypeId)
        {
            try
            {
                await _activityTypeRepositiry.DeleteActivityType(activityTypeId);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    }
}
