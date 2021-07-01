using Data.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<bool> VerifyLoginAsync(UserLoginCredentials user)
        {
            var userDb = await _userManager.FindByNameAsync(user.UserName);

            if (userDb != null)
            {
                var verifyPassword = await _signInManager.CheckPasswordSignInAsync(userDb, user.Password, user.IsPersistent);
                if (verifyPassword.Succeeded) {
                    user.IsPersistent = true;
                    await _signInManager.SignInAsync(userDb, user.IsPersistent);
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
    }
}
