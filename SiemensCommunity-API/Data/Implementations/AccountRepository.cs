using Data.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        private UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountRepository(ProjectDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }


        public async Task<TokenDetails> VerifyLoginAsync(UserLoginCredentials user)
        {
            var userDb = await _userManager.FindByEmailAsync(user.Email);

            if (user != null)
            {
                var verifyPassword = await _signInManager.CheckPasswordSignInAsync(userDb, user.Password, user.IsPersistent);
                if (verifyPassword.Succeeded)
                {
                    var role = await _userManager.GetRolesAsync(userDb);

                    var tokenDetails = new TokenDetails
                    {
                        UserId = userDb.Id,
                        UserRole = role.FirstOrDefault(),
                    };
                    return tokenDetails;
                }
                else
                    return null;
            }
            else
                return null;
        }


        public async Task<int> RegisterAsync(User user, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    try
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return user.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        Task<IEnumerable<User>> IGenericRepository<User>.GetAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<string> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }


        public async Task<bool> ResetPasswordAsync(ResetPassword resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
                return false;

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

            if (resetPassResult.Succeeded)
                return true;
            
            return false;
        }
    }
}
