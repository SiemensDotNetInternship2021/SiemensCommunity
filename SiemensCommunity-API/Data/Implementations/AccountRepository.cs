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

        public AccountRepository(ProjectDbContext context) : base(context)
        {

        }

        public Task<UserRegisterCredentials> AddAsync(UserRegisterCredentials entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterAsync(UserRegisterCredentials userRegistration)
        {
            var user = new User()
            {
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                Department = userRegistration.Department,
                OfficeFloor = userRegistration.OfficeFloor,
                PhoneNumber = userRegistration.PhoneNumber,
                Email = userRegistration.Email,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, userRegistration.Password);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return user;
        }

        Task<IEnumerable<UserRegisterCredentials>> IGenericRepository<UserRegisterCredentials>.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<UserRegisterCredentials> IAccountRepository.RegisterAsync(UserRegisterCredentials user)
        {
            throw new NotImplementedException();
        }
    }
}
