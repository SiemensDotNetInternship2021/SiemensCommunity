using AutoMapper;
using SiemensCommunity.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Api.Adapters
{
    public class RegisterAdapter
    {
        private readonly IMapper _registerUserAdapter;

        public RegisterAdapter()
        {
            var config = new MapperConfiguration(config => {
                config.CreateMap<UserRegistrationCredentials, Services.Models.Entities.UserRegistrationCredentials>();
                config.CreateMap<Services.Models.Entities.UserRegistrationCredentials, UserRegistrationCredentials>();
            });

            _registerUserAdapter = config.CreateMapper();
        }

        public Services.Models.Entities.UserRegistrationCredentials AdaptUserRegister(UserRegistrationCredentials register)
        {
            return _registerUserAdapter.Map<UserRegistrationCredentials, Services.Models.Entities.UserRegistrationCredentials>(register);
        }

        public UserRegistrationCredentials AdaptUserRegister(Services.Models.Entities.UserRegistrationCredentials register)
        {
            return _registerUserAdapter.Map<Services.Models.Entities.UserRegistrationCredentials, UserRegistrationCredentials>(register);
        }
    }
}
