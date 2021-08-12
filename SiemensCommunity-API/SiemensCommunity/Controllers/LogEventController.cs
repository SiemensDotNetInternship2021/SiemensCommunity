using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogEventController: Controller
    {
        private readonly ILogEventsService _logEventsService;

        public LogEventController(ILogEventsService logEventsService)
        {
            _logEventsService = logEventsService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var logEvents = await _logEventsService.GetAsync();
            return Ok(logEvents);
        }
    }
}
