using Data.Models;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        public Task<int> RegisterAsync(User user, string password);

        public Task<TokenDetails> VerifyLoginAsync(UserLoginCredentials userLoginCredentials);

        public Task<string> ForgotPasswordAsync(string email);

        public Task<bool> ResetPasswordAsync(ResetPassword resetPassword);
    }
}
