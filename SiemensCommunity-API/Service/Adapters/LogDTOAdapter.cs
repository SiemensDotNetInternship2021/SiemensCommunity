using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class LogDTOAdapter
    {
        private readonly IMapper _logDTOAdapter;

        public LogDTOAdapter()
        {
            var config = new MapperConfiguration(config =>
            {

                config.CreateMap<LogDTO, Data.Models.LogDTO>();
                config.CreateMap<Data.Models.LogDTO, LogDTO>();
            });

            _logDTOAdapter = config.CreateMapper();
        }


        public Data.Models.LogDTO Adapt(LogDTO log)
        {
            return _logDTOAdapter.Map<LogDTO, Data.Models.LogDTO>(log);
        }


        public LogDTO Adapt(Data.Models.LogDTO log)
        {
            return _logDTOAdapter.Map<Data.Models.LogDTO, LogDTO>(log);
        }

        public IEnumerable<LogDTO> AdaptEnumerable(IEnumerable<Data.Models.LogDTO> logs)
        {
            return _logDTOAdapter.Map<IEnumerable<Data.Models.LogDTO>, IEnumerable<LogDTO>>(logs);
        }
    }
}
