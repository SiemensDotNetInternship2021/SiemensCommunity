using Common;
using Data.Contracts;
using Microsoft.Extensions.Logging;
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
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly ILogService _logService;
        public UserService(IUserRepository userReposistory, Microsoft.Extensions.Logging.ILoggerFactory logger, ILogService logService)
        {
            _userReposistory = userReposistory;
            _logService = logService;
            _logger = logger.CreateLogger("UserService");
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
            try
            {
                var returnedUser = await _userReposistory.UpdateUser(_userDTOAdapter.Adapt(user));
                user = _userDTOAdapter.Adapt(returnedUser);
                _logger.LogInformation(MyLogEvents.InsertItem, "User successfully updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.UpdateUser, "Error while updating user with message " + ex.Message);
                 await _logService.SaveAsync(LogLevel.Error, MyLogEvents.InsertItem, ex.Message, ex.StackTrace);
            }
            return user;
        }
    }
}
