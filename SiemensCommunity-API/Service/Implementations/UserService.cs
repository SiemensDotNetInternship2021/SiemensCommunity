using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserDTOAdapter _userDTOAdapter = new UserDTOAdapter();

        private readonly IUserRepository _userReposistory; 
        public UserService(IUserRepository userReposistory)
        {
            _userReposistory = userReposistory;
        }

        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            var returnedUsers = await _userReposistory.GetAsync();
            return _userDTOAdapter.AdaptList(returnedUsers);
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var returnedUser = await _userReposistory.GetUserById(userId);
            return _userDTOAdapter.Adapt(returnedUser);
        }

        public async Task<IEnumerable<string>> GetRoles()
        {
            var returnedRoles = await _userReposistory.GetRoles();
            return returnedRoles;
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            var returnedUser = await _userReposistory.UpdateUser(_userDTOAdapter.Adapt(user));
            return _userDTOAdapter.Adapt(returnedUser);
        }
    }
}
