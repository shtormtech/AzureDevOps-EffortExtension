using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Effort.DB.Layer.Interfaces;
using Effort.Models;
using Microsoft.AspNetCore.Http;
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
        /// <param name="activityTypeRepositiry"></param>
        public ActivityTypesController(IActivityTypeRepository activityTypeRepositiry)
        {
            _activityTypeRepositiry = activityTypeRepositiry;
        }

        /// <summary>
        /// Получить все виды активностей
        /// </summary>
        /// <param name="isActual">Показать только актуальные (не удаленные)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ActivityType>>> Get(bool isActual = true)
        {
            return await _activityTypeRepositiry.GetActivityTypes(isActual) ;
        }

        /// <summary>
        /// Получить нужный вид активности
        /// </summary>
        /// <param name="id">Идентификатор активности</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ActivityType>> Get(long id)
        {
            var activity = await _activityTypeRepositiry.GetActivityType(id);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;

        }

        /// <summary>
        /// Добавить новый вид активности
        /// </summary>
        /// <param name="NewActivity">Новый вид активности</param>
        [HttpPost]
        public async Task Post([FromBody] ActivityType NewActivity)
        {
            await _activityTypeRepositiry.AddActivityType(NewActivity);
        }

        /*
        // PUT: api/ActivityType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        /// <summary>
        /// Удалить тип активности
        /// </summary>
        /// <param name="id">Идентификатор удаляемого типа активности</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _activityTypeRepositiry.DeleteActivityType(id);
        }
    }
}
