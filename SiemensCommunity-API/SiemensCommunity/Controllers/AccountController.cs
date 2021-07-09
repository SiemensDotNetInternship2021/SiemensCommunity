using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SiemensCommunity.Adapters;
using SiemensCommunity.Models;
using System.Net;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserAdapter _userAdapter = new UserAdapter();

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterCredentials registerCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var returnedUserId = await _accountService.RegisterAsync(_userAdapter.Adapt(registerCredentials));
                if (returnedUserId != 0)
                {
                    return Ok(returnedUserId);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginCredentials userLoginCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var responseLogin =await _accountService.VerifyLoginAsync(_userAdapter.Adapt(userLoginCredentials));

                if (responseLogin)
                    return Ok();
                else return BadRequest();
            }
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var result = await _accountService.ForgotPasswordAsync(email);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
