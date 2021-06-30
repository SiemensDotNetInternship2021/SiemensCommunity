using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class UserAdapter
    {
        private readonly IMapper _userAdapter;

        public UserAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserRegisterCredentials, Service.Models.UserRegisterCredentials>();
                config.CreateMap<Service.Models.UserRegisterCredentials, UserRegisterCredentials>();
                config.CreateMap<UserLoginCredentials, Service.Models.UserLoginCredentials>();
            });

            _userAdapter = config.CreateMapper();
        }

        public Service.Models.UserRegisterCredentials Adapt(UserRegisterCredentials user)
        {
            return _userAdapter.Map<UserRegisterCredentials, Service.Models.UserRegisterCredentials>(user);
        }

        public UserRegisterCredentials Adapt(Service.Models.UserRegisterCredentials user)
        {
            return _userAdapter.Map<Service.Models.UserRegisterCredentials, UserRegisterCredentials>(user);
        }

        public Service.Models.UserLoginCredentials Adapt(UserLoginCredentials userLoginCredentials)
        {
            return _userAdapter.Map<UserLoginCredentials, Service.Models.UserLoginCredentials > (userLoginCredentials);
        }
    }
}
