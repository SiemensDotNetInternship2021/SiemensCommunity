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
                var responseRegister = await _accountService.RegisterAsync(_userAdapter.Adapt(registerCredentials));
                if (responseRegister != null)
                {
                    return Ok(responseRegister);
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
    }
}
