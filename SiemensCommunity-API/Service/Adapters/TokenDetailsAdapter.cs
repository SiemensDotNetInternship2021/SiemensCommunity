using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class TokenDetailsAdapter
    {
        private readonly IMapper OptionDetailsDTO;

        public TokenDetailsAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<TokenDetails, Data.Models.TokenDetails>();
                config.CreateMap<Data.Models.TokenDetails, TokenDetails>();
            });

            OptionDetailsDTO = config.CreateMapper();
        }

        public Data.Models.TokenDetails Adapt(TokenDetails optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<TokenDetails, Data.Models.TokenDetails>(optionDetailsDTO);
        }

        public TokenDetails Adapt(Data.Models.TokenDetails optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<Data.Models.TokenDetails, TokenDetails>(optionDetailsDTO);
        }

        public List<TokenDetails> AdaptList(List<Data.Models.TokenDetails> optionDetailsDTO)
        {
            return OptionDetailsDTO.Map<List<Data.Models.TokenDetails>, List<TokenDetails>>(optionDetailsDTO);
        }
    }
}
