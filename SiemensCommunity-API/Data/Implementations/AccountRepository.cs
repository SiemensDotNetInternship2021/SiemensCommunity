using Data.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

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

        public async Task<bool> VerifyLoginAsync(UserLoginCredentials user)
        {
            var userDb = await _userManager.FindByEmailAsync(user.Email);

            if (user != null)
            {
                var verifyPassword = await _signInManager.CheckPasswordSignInAsync(userDb, user.Password, user.IsPersistent);
                if (verifyPassword.Succeeded) 
                {
                    //await _signInManager.SignInAsync(userDb, user.IsPersistent);

                    //token configuration? what to send with the token.
                    return true;
                }
                else
                    //to do: return exception
                    return false;
            }
            else
                return false;
        }

        public async Task<int> RegisterAsync(User user, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
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

          /*  if (user == null)

                 return error; */

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
