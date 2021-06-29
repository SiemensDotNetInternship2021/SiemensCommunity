using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class UserAdapter
    {
        private readonly IMapper _userAdapter;

        public UserAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserRegisterCredentials, Data.Models.UserRegisterCredentials>();
                config.CreateMap<Data.Models.UserRegisterCredentials, UserRegisterCredentials>();
            });

            _userAdapter = config.CreateMapper();
        }

        public Data.Models.UserRegisterCredentials Adapt(UserRegisterCredentials user)
        {
            return _userAdapter.Map<UserRegisterCredentials, Data.Models.UserRegisterCredentials>(user);
        }

        public UserRegisterCredentials Adapt(Data.Models.UserRegisterCredentials user)
        {
            return _userAdapter.Map<Data.Models.UserRegisterCredentials, UserRegisterCredentials>(user);
        }
    }
}
