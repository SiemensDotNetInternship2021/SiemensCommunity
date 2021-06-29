using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IAccountRepository : IGenericRepository<UserRegisterCredentials>
    {
        public Task<UserRegisterCredentials> RegisterAsync(UserRegisterCredentials user);

    }
}
