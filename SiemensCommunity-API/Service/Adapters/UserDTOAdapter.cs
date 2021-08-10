using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class UserDTOAdapter
    {
        private readonly IMapper _userDTOAdapter;

        public UserDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, Data.Models.UserDTO>();
                config.CreateMap<Data.Models.UserDTO, UserDTO>();
                
            });

            _userDTOAdapter = config.CreateMapper();
        }


        public Data.Models.UserDTO Adapt(UserDTO user)
        {
            return _userDTOAdapter.Map<UserDTO, Data.Models.UserDTO>(user);
        }

        public UserDTO Adapt(Data.Models.UserDTO user)
        {
            return _userDTOAdapter.Map<Data.Models.UserDTO, UserDTO>(user);
        }

        public IEnumerable<UserDTO> AdaptList(IEnumerable<Data.Models.UserDTO> users)
        {
            return _userDTOAdapter.Map<IEnumerable<Data.Models.UserDTO>, List<UserDTO>>(users);
        }
    }
}
