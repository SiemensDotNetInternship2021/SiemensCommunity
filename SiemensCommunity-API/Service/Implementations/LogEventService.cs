using Data.Contracts;
using Service.Contracts;
using Service.Models;
using Service.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class LogEventService : ILogEventsService
    {
        private readonly ILogEventRepository _logEventRepository;
        private readonly LogEventAdapter _logEventAdapter= new LogEventAdapter();

        public LogEventService(ILogEventRepository logEventRepository)
        {
            _logEventRepository = logEventRepository;
        }
        public async Task<IEnumerable<LogEvent>> GetAsync()
        {
            var result = await _logEventRepository.GetAsync();
            return _logEventAdapter.AdaptEnumerable(result);
        }
    }
}
