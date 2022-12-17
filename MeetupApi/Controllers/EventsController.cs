using AutoMapper;
using Contracts;
using Entities.Dtos;
using Entities.Models;
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
    }
}
