using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class OptionDetailsDTOAdapter
    {
        private readonly IMapper OptionDetailsDTO;

        public OptionDetailsDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<OptionDetailsDTO, Service.Models.OptionDetailsDTO>();
                config.CreateMap<Service.Models.OptionDetailsDTO, OptionDetailsDTO>();
            });

            OptionDetailsDTO = config.CreateMapper();
        }

        public Service.Models.OptionDetailsDTO Adapt(OptionDetailsDTO optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<OptionDetailsDTO, Service.Models.OptionDetailsDTO>(optionDetailsDTO);
        }

        public OptionDetailsDTO Adapt(Service.Models.OptionDetailsDTO optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<Service.Models.OptionDetailsDTO, OptionDetailsDTO>(optionDetailsDTO);
        }

        public List<OptionDetailsDTO> AdaptList(List<Service.Models.OptionDetailsDTO> optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<List<Service.Models.OptionDetailsDTO>, List<OptionDetailsDTO>>(optionDetailsDTO);
        }
    }
}
