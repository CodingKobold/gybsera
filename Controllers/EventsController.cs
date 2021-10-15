using Gybs.Logic.Events;
using Gybsera.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gybsera.Controllers
{
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IEventBus _eventBus;

        public EventsController(ILogger<EventsController> logger, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddWelcomingGrypser")]
        public async Task<ActionResult> AddWelcomingGrypser()
        {
            await _eventBus.SubscribeAsync<SayHelloToNewGrypserEvent>(e => SayHelloToGrypser(e.Nickname));
            return Ok();
        }

        [HttpGet]
        [Route("SendGrypser")]
        public async Task<ActionResult> SendGrypser(string nickname)
        {
            await _eventBus.SendAsync(new SayHelloToNewGrypserEvent { Nickname = nickname });
            return Ok();
        }

        private Task SayHelloToGrypser(string nickname)
        {
            _logger.LogDebug($"Hello {nickname}. Time for chrzest!");
            return Task.CompletedTask;
        }
    }
}
