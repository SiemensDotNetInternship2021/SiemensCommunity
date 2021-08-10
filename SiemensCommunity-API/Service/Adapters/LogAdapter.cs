using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class LogAdapter
    {

        private readonly IMapper _logAdapter;

        public LogAdapter()
        {
            var config = new MapperConfiguration(config =>
            {

                config.CreateMap<Log, Data.Models.Log>();
                config.CreateMap<Data.Models.Log, Log>();
            });

            _logAdapter = config.CreateMapper();
        }


        public Data.Models.Log Adapt(Log log)
        {
            return _logAdapter.Map<Log, Data.Models.Log>(log);
        }


        public Log Adapt(Data.Models.Log log)
        {
            return _logAdapter.Map<Data.Models.Log, Log>(log);
        }
    }
}
