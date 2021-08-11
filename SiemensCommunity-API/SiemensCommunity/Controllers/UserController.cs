using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAsync();
            return Ok(users);
        }

        [HttpGet("getUser")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _userService.GetRoles();
            return Ok(roles);
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            return Ok(user);
        }
    }
}
