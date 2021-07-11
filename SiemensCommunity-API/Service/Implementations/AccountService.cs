using Data.Contracts;
using Microsoft.AspNetCore.Identity.UI.Services;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountReposistory;
        private readonly UserAdapter _userAdapter = new UserAdapter();
        private readonly IEmailService _emailService;

        public AccountService(IAccountRepository accountReposistory, IEmailService emailService)
        {
            _accountReposistory = accountReposistory;
            _emailService = emailService;
        }

        public async Task<int> RegisterAsync(UserRegisterCredentials userCredentials)
        {
            var returnedUserId = await _accountReposistory.RegisterAsync(_userAdapter.AdaptToUserIdentity(userCredentials), userCredentials.Password);
            return returnedUserId;
        }

        public async Task<bool> VerifyLoginAsync(UserLoginCredentials user)
        {
            var returned = await _accountReposistory.VerifyLoginAsync(_userAdapter.AdaptFromUserData(user));
            return returned;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var token = await _accountReposistory.ForgotPasswordAsync(email);
            var url = "http://localhost:port/account/resetpassword?token=" + token + "&email=" + email;
            var emailBody= "Copy link to reset password: " + url;
            var message = new EmailData
            {
                EmailBody = emailBody,
                EmailSubject = "Recover password",
                EmailToId = email,
                EmailToName = email
            };
            var result = _emailService.SendEmail(message);
            return result;
        }
    }
}

