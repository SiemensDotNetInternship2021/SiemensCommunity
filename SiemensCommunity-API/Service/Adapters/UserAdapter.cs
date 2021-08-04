using AutoMapper;
using Service.Models;

namespace Service.Adapters
{
    public class UserAdapter
    {
        private readonly IMapper _userAdapter;

        public UserAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserRegisterCredentials, Data.Models.User>();
                config.CreateMap<UserLoginCredentials, Data.Models.UserLoginCredentials>();
            });

            _userAdapter = config.CreateMapper();
        }


        public UserRegisterCredentials AdaptFromUserIdentity(Data.Models.User user)
        {
            return _userAdapter.Map<Data.Models.User, UserRegisterCredentials>(user);
        }


        public Data.Models.User AdaptToUserIdentity(UserRegisterCredentials user)
        {
            return _userAdapter.Map<UserRegisterCredentials, Data.Models.User>(user);
        }


        public Data.Models.UserLoginCredentials AdaptFromUserData(UserLoginCredentials userLoginCredentials)
        {
            return _userAdapter.Map<UserLoginCredentials, Data.Models.UserLoginCredentials>(userLoginCredentials);
        }
    }
}
