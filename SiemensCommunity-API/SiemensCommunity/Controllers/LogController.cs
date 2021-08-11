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
    }
}
