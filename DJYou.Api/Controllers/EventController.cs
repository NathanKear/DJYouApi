using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DJYou.Data;
using DJYou.Services;
using Microsoft.AspNetCore.Mvc;

namespace DJYouAPI.Controllers
{
    [Route("api/event")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // POST api/values
        [HttpPost("", Name = "Create Event")]
        public ActionResult CreateEvent()
        {
            Event evnt = _eventService.CreateEvent();

            return Created($"/event/{evnt.Id}", evnt);
        }

        // POST api/values
        [HttpGet("{code}", Name = "Join Event")]
        public ActionResult JoinEvent(string code)
        {
            Event evnt = _eventService.GetEvent(code);

            if (evnt == default(Event))
                return NotFound();

            return Ok(evnt);
        }
    }
}
