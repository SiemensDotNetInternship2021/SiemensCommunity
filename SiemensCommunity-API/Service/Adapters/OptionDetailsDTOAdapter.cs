using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class OptionDetailsDTOAdapter
    {
        private readonly IMapper OptionDetailsDTO;

        public OptionDetailsDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<OptionDetailsDTO, Data.Models.OptionDetailsDTO>();
                config.CreateMap<Data.Models.OptionDetailsDTO, OptionDetailsDTO>();
            });

            OptionDetailsDTO = config.CreateMapper();
        }

        public Data.Models.OptionDetailsDTO Adapt(OptionDetailsDTO optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<OptionDetailsDTO, Data.Models.OptionDetailsDTO>(optionDetailsDTO);
        }

        public OptionDetailsDTO Adapt(Data.Models.OptionDetailsDTO optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<Data.Models.OptionDetailsDTO, OptionDetailsDTO>(optionDetailsDTO);
        }

        public List<OptionDetailsDTO> AdaptList(List<Data.Models.OptionDetailsDTO> optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<List<Data.Models.OptionDetailsDTO>, List<OptionDetailsDTO>>(optionDetailsDTO);
        }
    }
}
