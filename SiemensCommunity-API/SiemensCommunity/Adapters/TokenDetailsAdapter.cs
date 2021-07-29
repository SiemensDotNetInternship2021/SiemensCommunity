using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class TokenDetailsAdapter
    {
        private readonly IMapper OptionDetailsDTO;

        public TokenDetailsAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<TokenDetails, Service.Models.TokenDetails>();
                config.CreateMap<Service.Models.TokenDetails, TokenDetails>();
            });

            OptionDetailsDTO = config.CreateMapper();
        }

        public Service.Models.TokenDetails Adapt(TokenDetails optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<TokenDetails, Service.Models.TokenDetails>(optionDetailsDTO);
        }

        public TokenDetails Adapt(Service.Models.TokenDetails optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<Service.Models.TokenDetails, TokenDetails>(optionDetailsDTO);
        }

        public List<TokenDetails> AdaptList(List<Service.Models.TokenDetails> optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<List<Service.Models.TokenDetails>, List<TokenDetails>>(optionDetailsDTO);
        }
    }
}
