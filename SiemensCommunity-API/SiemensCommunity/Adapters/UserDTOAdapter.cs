using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class UserDTOAdapter
    {
        private readonly IMapper _userDTOAdapter;
        public UserDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, Service.Models.UserDTO>();
                config.CreateMap<Service.Models.UserDTO, UserDTO>();
            });

            _userDTOAdapter = config.CreateMapper();
        }

        public Service.Models.UserDTO Adapt(UserDTO user)
        {
            return _userDTOAdapter.Map<UserDTO, Service.Models.UserDTO>(user);
        }

        public UserDTO Adapt(Service.Models.UserDTO user)
        {
            return _userDTOAdapter.Map<Service.Models.UserDTO, UserDTO>(user);
        }

        public IEnumerable<UserDTO> AdaptList(IEnumerable<Service.Models.UserDTO> users)
        {
            return _userDTOAdapter.Map<IEnumerable<Service.Models.UserDTO>, List<UserDTO>>(users);
        }
    }
}
