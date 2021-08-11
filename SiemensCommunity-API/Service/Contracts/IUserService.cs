using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDTO>> GetAsync();

        public Task<UserDTO> GetUserById(int userId);

        public Task<IEnumerable<string>> GetRoles();
    }
}
