using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using SiemensCommunity.Adapters;
using SiemensCommunity.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserAdapter _userAdapter = new UserAdapter();
        private readonly ResetPasswordAdapter _resetPasswordAdapter = new ResetPasswordAdapter();
      //  private readonly ApplicationSettings _applicationSettings;

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
                var returnedTokenDetails = await _accountService.VerifyLoginAsync(_userAdapter.Adapt(userLoginCredentials));

                if (returnedTokenDetails != null)
                {
                    IdentityOptions _identityOptions = new IdentityOptions();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                    {
                          new Claim("UserId", returnedTokenDetails.UserId.ToString()),
                          new Claim(_identityOptions.ClaimsIdentity.RoleClaimType, returnedTokenDetails.UserRole)
                    }),
                        Expires = DateTime.UtcNow.AddMinutes(60),
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok( new { token });
                }
                else return BadRequest();
            }
        }

        [HttpGet("forgotPassword")]
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

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var adapt = _resetPasswordAdapter.Adapt(resetPassword);

            var result = await _accountService.ResetPasswordAsync(adapt);

            if (result == false)
                return BadRequest();

            return Ok();
        }
    }
}
