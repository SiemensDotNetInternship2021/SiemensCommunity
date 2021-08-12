using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class LogEventAdapter
    {
        private readonly IMapper _logEventAdapterl;

        public LogEventAdapter()
        {
            var config = new MapperConfiguration(config =>
            {

                config.CreateMap<LogEvent, Data.Models.LogEvent>();
                config.CreateMap<Data.Models.LogEvent, LogEvent>();
            });

            _logEventAdapterl = config.CreateMapper();
        }


        public Data.Models.LogEvent Adapt(LogEvent log)
        {
            return _logEventAdapterl.Map<LogEvent, Data.Models.LogEvent>(log);
        }


        public LogEvent Adapt(Data.Models.LogEvent log)
        {
            return _logEventAdapterl.Map<Data.Models.LogEvent, LogEvent>(log);
        }


        public IEnumerable<LogEvent> AdaptEnumerable(IEnumerable<Data.Models.LogEvent> logs)
        {
            return _logEventAdapterl.Map<IEnumerable<Data.Models.LogEvent>, IEnumerable<LogEvent>>(logs);
        }


        public IEnumerable<Data.Models.LogEvent> AdaptEnumerable(IEnumerable<LogEvent> logs)
        {
            return _logEventAdapterl.Map<IEnumerable<LogEvent>, IEnumerable<Data.Models.LogEvent>>(logs);
        }
    }
}
