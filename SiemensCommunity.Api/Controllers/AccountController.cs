using Microsoft.AspNetCore.Mvc;
using SiemensCommunity.Api.Adapters;
using SiemensCommunity.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly RegisterAdapter _registerAdapter;

        public AccountController()
        {
            _registerAdapter = new RegisterAdapter();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationCredentials user)
        {
            Services.Models.Entities.UserRegistrationCredentials userRegistration = new Services.Models.Entities.UserRegistrationCredentials();

            userRegistration = _registerAdapter.AdaptUserRegister(user);

            return View(user);
        }

        [HttpGet]
        [Route("TestRoute")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
