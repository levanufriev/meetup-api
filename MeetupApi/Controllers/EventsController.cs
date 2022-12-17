using Contracts;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Serilog;

namespace MeetupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository repository;
        private readonly ILogger<EventsController> logger;

        public EventsController(IEventRepository repository, ILogger<EventsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await repository.GetAllEventsAsync(false);
            return Ok(events);
        }
    }
}
