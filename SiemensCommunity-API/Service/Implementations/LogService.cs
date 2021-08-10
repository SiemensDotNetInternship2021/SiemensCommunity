using Data.Contracts;
using Data.Implementations;
using Microsoft.Extensions.Logging;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private LogAdapter logAdapter = new LogAdapter();
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<bool> SaveAsync(LogLevel logLevel, int logEvent, string message, string stackTrace)
        {
            var log = logAdapter.Adapt(new Log
            {
                LogLevel = logLevel,
                LogEvent = logEvent,
                LogMessage = message,
                StackTrace = stackTrace
            });

            var result = await _logRepository.AddAsync(log);

            return (result!= null);
        }
    }
}
