using AutoMapper;
using Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MeetupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository repository;
        private readonly ILogger<EventsController> logger;
        private readonly IMapper mapper;

        public EventsController(IEventRepository repository, ILogger<EventsController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await repository.GetAllEventsAsync(false);
            var eventsDto = mapper.Map<IEnumerable<EventDto>>(events);
            return Ok(eventsDto);
        }

        [HttpGet("{id}", Name = "EventById")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            var _event = await repository.GetEventAsync(id, false);
            var eventDto = mapper.Map<EventDto>(_event);
            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventForCreationDto eventForCreationDto)
        {
            if (eventForCreationDto == null)
            {
                logger.LogError("EventForCreationDto is null");
                return BadRequest("EventForCreationDto is null");
            }

            var _event = mapper.Map<Event>(eventForCreationDto);
            repository.CreateEvent(_event);
            await repository.SaveAsync();

            var eventDto = mapper.Map<EventDto>(_event);
            return CreatedAtRoute("EventById", new { id = eventDto.Id }, eventDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] EventForUpdateDto eventForUpdateDto)
        {
            if (eventForUpdateDto == null)
            {
                logger.LogError("EventForUpdateDto is null");
                return BadRequest("EventForUpdateDto is null");
            }

            var _event = await repository.GetEventAsync(id, true);
            if (_event == null)
            {
                logger.LogError($"Event with id: {id} doesn't exist in the database");
                return NotFound();
            }

            mapper.Map(eventForUpdateDto, _event);
            await repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var _event = await repository.GetEventAsync(id, false);
            if (_event == null)
            {
                logger.LogError($"Event with id: {id} doesn't exist in the database");
                return NotFound();
            }

            repository.DeleteEvent(_event);
            await repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateEvent(Guid id, [FromBody] JsonPatchDocument<EventForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                logger.LogError("patchDoc object is null.");
                return BadRequest("patchDoc object is null");
            }

            var _event = await repository.GetEventAsync(id, true);
            if (_event == null)
            {
                logger.LogError($"Event with id: {id} doesn't exist in the database");
                return NotFound();
            }

            var eventToPatch = mapper.Map<EventForUpdateDto>(_event);
            patchDoc.ApplyTo(eventToPatch);
            mapper.Map(eventToPatch, _event);
            await repository.SaveAsync();

            return NoContent();
        }
    }
}
