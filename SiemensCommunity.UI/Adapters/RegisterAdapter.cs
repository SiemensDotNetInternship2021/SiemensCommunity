using AutoMapper;
using SiemensCommunity.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.UI.Adapters
{
    public class RegisterAdapter
    {
            private readonly IMapper _registerAdapter;

            public RegisterAdapter()
            {
                var config = new MapperConfiguration(config => {
                    config.CreateMap<RegisterViewModel, Api.Models.Entities.UserRegistrationCredentials>();
                    config.CreateMap<Api.Models.Entities.UserRegistrationCredentials, RegisterViewModel>();
                });

            _registerAdapter = config.CreateMapper();
            }

            public Api.Models.Entities.UserRegistrationCredentials AdaptProduct(RegisterViewModel register)
            {
                return _registerAdapter.Map<RegisterViewModel, Api.Models.Entities.UserRegistrationCredentials>(register);
            }

            public RegisterViewModel AdaptProduct(Api.Models.Entities.UserRegistrationCredentials register)
            {
                return _registerAdapter.Map<Api.Models.Entities.UserRegistrationCredentials, RegisterViewModel>(register);
            }
    }
}
