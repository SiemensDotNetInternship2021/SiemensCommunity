using Data.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Identity;
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

        public AccountRepository(ProjectDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager =userManager;
        }

        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                return user;
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
