using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRepository : IGenericRepository<UserDTO>
    {
        public Task<UserDTO> GetUserById(int userId);

        public Task<IEnumerable<string>> GetRoles();

        public Task<UserDTO> UpdateUser(UserDTO userDetails);
    }
}
