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
                /*config.CreateMap<UserRegisterCredentials, Data.Models.UserRegisterCredentials>();
                  config.CreateMap<Data.Models.UserRegisterCredentials, UserRegisterCredentials>();*/
                config.CreateMap<UserRegisterCredentials, Data.Models.User>();
                config.CreateMap<UserLoginCredentials, Data.Models.UserLoginCredentials>();
            });

            _userAdapter = config.CreateMapper();
        }


        //TO DO: resolve error
        public UserRegisterCredentials AdaptFromUserIdentity(Data.Models.User user)
        {
            var returned = _userAdapter.Map<Data.Models.User, UserRegisterCredentials>(user);
            return returned;
        }

        public Data.Models.User AdaptToUserIdentity(UserRegisterCredentials user)
        {
            return _userAdapter.Map<UserRegisterCredentials, Data.Models.User>(user);
        }

        /*        public Data.Models.UserRegisterCredentials Adapt(UserRegisterCredentials user)
                {
                    return _userAdapter.Map<UserRegisterCredentials, Data.Models.UserRegisterCredentials>(user);
                }

                public UserRegisterCredentials Adapt(Data.Models.UserRegisterCredentials user)
                {
                    return _userAdapter.Map<Data.Models.UserRegisterCredentials, UserRegisterCredentials>(user);
                }
        */


        public Data.Models.UserLoginCredentials AdaptFromUserData(UserLoginCredentials userLoginCredentials)
        {
            return _userAdapter.Map<UserLoginCredentials, Data.Models.UserLoginCredentials> (userLoginCredentials);
        }
    }
}
