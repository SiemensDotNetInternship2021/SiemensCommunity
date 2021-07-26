using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAccountService
    {
        public Task<int> RegisterAsync(UserRegisterCredentials userCredentials);
        public Task<int> VerifyLoginAsync(UserLoginCredentials user);
        public Task<bool> ForgotPasswordAsync(string email);
        public Task<bool> ResetPasswordAsync(ResetPassword resetPassword);
    }
}
