using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ScheduleController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)

        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet, Authorize]
        public IActionResult GetSchedules()
        {
            var schedules = _repository.Schedule.GetAllSchedules(trackChanges: false);
            var ScheduleDto = _mapper.Map<IEnumerable<ScheduleDto>>(schedules);
            return Ok(ScheduleDto);
        }

        [HttpGet("{id}", Name = "ScheduleById"), Authorize]
        public IActionResult GetSchedule(Guid id)
        {
            var Schedule = _repository.Schedule.GetSchedule(id, trackChanges: false);
            if (Schedule == null)
            {
                _logger.LogInfo($"Schedule with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var ScheduleDto = _mapper.Map<ScheduleDto>(Schedule);
                return Ok(ScheduleDto);
            }
        }

        [HttpPost, Authorize]
        public IActionResult CreateSchedule ([FromBody] ScheduleForCreationDto Schedule)
        {
            if (Schedule == null)
            {
                _logger.LogError("ScheduleForCreationDto object sent from client is null.");
                return BadRequest("ScheduleForCreationDto object is null");
            }
            var ScheduleEntity = _mapper.Map<ScheduleDto>(Schedule);
            _repository.Schedule.CreateSchedule(ScheduleEntity);
            _repository.Save();
            var ScheduleToReturn = _mapper.Map<ScheduleDto>(ScheduleEntity);
            return CreatedAtRoute("ScheduleById", new { id = ScheduleToReturn.Id }, ScheduleToReturn);

        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteSchedule(Guid id)
        {
            var Schedule = _repository.Schedule.GetSchedule(id, trackChanges: false);
            if (Schedule == null)
            {
                _logger.LogInfo($"Schedule with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Schedule.DeleteSchedule(Schedule);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}"), Authorize]
        public IActionResult UpdateSchedule(Guid id, [FromBody] ScheduleForUpdateDto Schedule)
        {
            if (Schedule == null)
            {
                _logger.LogError("ScheduleForUpdateDto object sent from client is null.");
                return BadRequest("CompanyForUpdateDto object is null");
            }
            var ScheduleEntity = _repository.Schedule.GetSchedule(id, trackChanges: true);
            if (ScheduleEntity == null)
            {
                _logger.LogInfo($"Schedule with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(Schedule, ScheduleEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
