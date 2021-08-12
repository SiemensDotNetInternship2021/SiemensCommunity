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
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var logs = await _logService.GetAsync();
            return Ok(logs);
        }

        [HttpGet("getByLogLevel")]
        public async Task<IActionResult> GetByLogLevel(int logLevelId)
        {
            var logs = await _logService.GetByLogLevel(logLevelId);
            return Ok(logs);
        }

        [HttpGet("getByLogEvent")]
        public async Task<IActionResult> GetByLogEvent(int logEventId)
        {
            var logs = await _logService.GetByLogEvent(logEventId);
            return Ok(logs);
        }

        [HttpGet("getLogsByLevelAndEvent")]
        public async Task<IActionResult> GetLogsByLevelAndEvent(int logLevelId, int logEventId)
        {
            var logs = await _logService.GetLogsByLevelAndEvent(logLevelId, logEventId);
            return Ok(logs);
        }
    }
}
