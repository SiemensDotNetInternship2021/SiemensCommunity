using Service.Models;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAccountService
    {
        public Task<int> RegisterAsync(UserRegisterCredentials userCredentials);

        public Task<TokenDetails> VerifyLoginAsync(UserLoginCredentials user);

        public Task<bool> ForgotPasswordAsync(string email);

        public Task<bool> ResetPasswordAsync(ResetPassword resetPassword);
    }
}
