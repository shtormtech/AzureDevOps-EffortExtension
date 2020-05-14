using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Effort.Models;
using Effort.DB.Layer.Interfaces;

namespace EffortAPIService.Controllers
{

    /// <summary>
    /// Контроллер для работы со списаниями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly ITimesheetRepository _timesheetRepository;

        /// <summary>
        /// Конструктор контроллера для работы со списаниями
        /// </summary>
        /// <param name="timesheetRepository"></param>
        public TimesheetsController(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        /// <summary>
        /// Получить трудозатраты
        /// </summary>
        /// <param name="WorkItemIds">Массив идентификаторов рабочих элементов</param>
        /// <param name="UserId">Пользователь</param>
        /// <param name="isActual">Только актуальные (не удаленные)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Timesheet>>> GetTimesheets(string WorkItemIds = "", string UserId = "", bool isActual = true)
        {
            long[] wids = null;

            if (WorkItemIds != "")
            {
                try
                {
                    wids = WorkItemIds.Split(',').Select(s => long.Parse(s)).ToArray();
                }
                catch (FormatException)
                {
                    return BadRequest("Массив \"WorkItemIds\" не распознан. Небоходимый формат \"workItemids=1,2,3\" "); 
                }
            }
            return await _timesheetRepository.GetTimesheets(wids, UserId, isActual);
        }

        /// <summary>
        /// Получить списание
        /// </summary>
        /// <param name="id">Идентификаотр списания</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Timesheet>> GetTimesheet(long id)
        {
            var timesheet = await _timesheetRepository.GetTimesheet(id);

            if (timesheet == null)
            {
                return NotFound();
            }

            return timesheet;
        }

        /// <summary>
        /// Изменить списание
        /// </summary>
        /// <param name="id">Идентификатор изменяемого списания</param>
        /// <param name="timesheet">Новое состояние списания</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesheet(long id, [FromBody] Timesheet timesheet)
        {
            if (id != timesheet.Id)
            {
                return BadRequest();
            }
                        
            try
            {
                await _timesheetRepository.EditTimesheet(id, timesheet);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }
        
        /// <summary>
        /// Добавить трудозатраты
        /// </summary>
        /// <param name="timesheet">Новая запись о трудозатратах</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Timesheet>> PostTimesheet([FromBody] Timesheet timesheet)
        {
            return await _timesheetRepository.AddTimesheet(timesheet);
        }

        /// <summary>
        /// Удалить списание
        /// </summary>
        /// <param name="id">Идентификатор удаляемго списания</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Timesheet>> DeleteTimesheet(long id)
        {
            var timesheet = await _timesheetRepository.DeleteTimesheet(id);
            if (timesheet == null)
            {
                return NotFound();
            }
            return timesheet;
        }

        private bool TimesheetExists(long id)
        {
            return _timesheetRepository.TimesheetExists(id);
        }

        /// <summary>
        /// Добавить трудозатраты
        /// </summary>
        /// <param name="timesheets">Список добавляемых трудозатрат</param>
        /// <returns></returns>
        [HttpPost("api/addTimesheetBulk")]
        public async Task<ActionResult> addTimesheetBulk([FromBody] List<Timesheet> timesheets)
        {
            await _timesheetRepository.AddTimesheets(timesheets);

            return Ok();
        }

    }
}
