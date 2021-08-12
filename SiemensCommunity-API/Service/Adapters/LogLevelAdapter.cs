using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Adapters
{
    public class LogLevelAdapter
    {

        private readonly IMapper _logLevelAdapter;

        public LogLevelAdapter()
        {
            var config = new MapperConfiguration(config =>
            {

                config.CreateMap<LogLevelModel, Data.Models.AddProduct>();
                config.CreateMap<Data.Models.LogLevel, LogLevelModel>();
            });

            _logLevelAdapter = config.CreateMapper();
        }


        public Data.Models.LogLevel Adapt(LogLevelModel log)
        {
            return _logLevelAdapter.Map<LogLevelModel, Data.Models.LogLevel>(log);
        }


        public LogLevelModel Adapt(Data.Models.LogLevel log)
        {
            return _logLevelAdapter.Map<Data.Models.LogLevel, LogLevelModel>(log);
        }

        public IEnumerable<LogLevelModel> AdaptEnumerable(IEnumerable<Data.Models.LogLevel> logs)
        {
            return _logLevelAdapter.Map<IEnumerable<Data.Models.LogLevel>, IEnumerable<LogLevelModel>>(logs);
        }
        public IEnumerable<Data.Models.LogLevel> AdaptEnumerable(IEnumerable<LogLevelModel> logs)
        {
            return _logLevelAdapter.Map<IEnumerable<LogLevelModel>, IEnumerable<Data.Models.LogLevel>>(logs);
        }
    }
}
