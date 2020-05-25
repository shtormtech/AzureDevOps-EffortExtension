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
        private readonly IActivityTypeRepository _activityTypeRepository;
        /// <summary>
        /// Конструктор контроллера активностей
        /// </summary>
        /// <param name="activityTypeRepository"></param>
        public ActivityTypesController(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository;
        }

        /// <summary>
        /// Получить все виды активностей
        /// </summary>
        /// <param name="isDeleted">Показать удаленные типы активностей</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ActivityType>>> Get(bool isDeleted = false)
        {
            return await _activityTypeRepository.GetActivityTypes(isDeleted);
        }

        /// <summary>
        /// Получить нужный вид активности
        /// </summary>
        /// <param name="activityTypeId">Идентификатор активности</param>
        /// <returns></returns>
        [HttpGet("{activityTypeId}", Name = "Get")]
        public async Task<ActionResult<ActivityType>> Get(long activityTypeId)
        {
            var activity = await _activityTypeRepository.GetActivityType(activityTypeId);

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
            return await _activityTypeRepository.AddActivityType(NewActivityType);
        }

        
        // PUT: api/ActivityType/5
        [HttpPut("{activityTypeId}")]
        public async Task<ActionResult> UpdateActivityType(long activityTypeId, [FromBody] ActivityType activityType)
        {
            if ((activityTypeId != activityType.Id) || activityType.Deleted)
            {
                return BadRequest();
            }

            try
            {
                await _activityTypeRepository.UpdateActivityType(activityType);
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
        /// <param name="activityTypeId">Идентификатор удаляемого типа активности</param>
        /// <returns></returns>
        [HttpDelete("{activityTypeId}")]
        public async Task<IActionResult> Delete(long activityTypeId)
        {
            try
            {
                await _activityTypeRepository.DeleteActivityType(activityTypeId);
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
