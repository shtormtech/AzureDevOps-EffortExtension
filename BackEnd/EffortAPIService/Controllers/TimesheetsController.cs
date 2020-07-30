using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Effort.Models;
using Effort.DB.Layer.Interfaces;
using Effort.Models.Dto;

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
        /// <param name="isDeleted">Только актуальные (не удаленные)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Timesheet>>> GetTimesheets(string WorkItemIds = "", string UserId = "", bool isDeleted = false)
        {
            int[] wids = null;

            if (WorkItemIds != "")
            {
                try
                {
                    wids = WorkItemIds.Split(',').Select(s => int.Parse(s)).ToArray();
                }
                catch (FormatException)
                {
                    return BadRequest("Массив \"WorkItemIds\" не распознан. Небоходимый формат \"workItemids=1,2,3\" "); 
                }
            }
            return await _timesheetRepository.GetTimesheets(wids, UserId, isDeleted);
        }

        /// <summary>
        /// Получить списание
        /// </summary>
        /// <param name="timesheetId">Идентификаотр списания</param>
        /// <returns></returns>
        [HttpGet("{timesheetId}")]
        public async Task<ActionResult<Timesheet>> GetTimesheet(long timesheetId)
        {
            var timesheet = await _timesheetRepository.GetTimesheet(timesheetId);

            if (timesheet == null)
            {
                return NotFound();
            }

            return timesheet;
        }

        /// <summary>
        /// Изменить списание
        /// </summary>
        /// <param name="timesheetId">Идентификатор изменяемого списания</param>
        /// <param name="timesheet">Новое состояние списания</param>
        /// <returns></returns>
        [HttpPut("{timesheetId}")]
        public async Task<IActionResult> PutTimesheet(long timesheetId, [FromBody] Timesheet timesheet)
        {
            if (timesheetId != timesheet.Id || timesheet.IsDeleted)
            {
                return BadRequest();
            }
                        
            try
            {
                await _timesheetRepository.UpdateTimesheet(timesheet);
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
        public async Task<ActionResult<Timesheet>> PostTimesheet([FromBody] TimesheetDto timesheet)
        {
            return await _timesheetRepository.AddTimesheet(timesheet);
        }

        /// <summary>
        /// Удалить списание
        /// </summary>
        /// <param name="id">Идентификатор удаляемго списания</param>
        /// <returns></returns>
        [HttpDelete("{timesheetId}")]
        public async Task<ActionResult> DeleteTimesheet(long timesheetId)
        {
            try
            {
                await _timesheetRepository.DeleteTimesheet(timesheetId);
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

        /// <summary>
        /// Добавить трудозатраты
        /// </summary>
        /// <param name="timesheets">Список добавляемых трудозатрат</param>
        /// <returns></returns>
        [HttpPost("api/addTimesheetBulk")]
        public async Task<ActionResult<List<Timesheet>>> addTimesheetBulk([FromBody] List<Timesheet> timesheets)
        {
            return await _timesheetRepository.AddTimesheets(timesheets);
        }

    }
}
