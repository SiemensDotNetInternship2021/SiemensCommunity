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
    public class LogLevelController : Controller
    {
        private readonly ILogLevelService _logLevelService;

        public LogLevelController(ILogLevelService logLevelService)
        {
            _logLevelService = logLevelService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Index()
        {
            var logLevels = await _logLevelService.GetAsync();
            return Ok(logLevels);
        }
    }
}
