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
        private LogAdapter _logAdapter = new LogAdapter();
        private LogDTOAdapter _logDTOAdapter = new LogDTOAdapter();
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<LogDTO>> GetAsync()
        {
            var logs = await _logRepository.ShowAsync();
            return _logDTOAdapter.AdaptEnumerable(logs);
        }

        public async Task<IEnumerable<LogDTO>> GetByLogEvent(int logEventId)
        {
            var logs = await _logRepository.GetByLogEvent(logEventId);
            return _logDTOAdapter.AdaptEnumerable(logs);
        }

        public async Task<IEnumerable<LogDTO>> GetByLogLevel(int logLevelId)
        {
            var logs = await _logRepository.GetByLogLevel(logLevelId);
            return _logDTOAdapter.AdaptEnumerable(logs);
        }

        public async Task<IEnumerable<LogDTO>> GetLogsByLevelAndEvent(int logLevelId, int logEventId)
        {
            var logs = await _logRepository.GetLogsByLevelAndEvent(logLevelId, logEventId);
            return _logDTOAdapter.AdaptEnumerable(logs);
        }

        public async Task<bool> SaveAsync(LogLevel logLevel, int logEvent, string message, string stackTrace)
        {
            var log = _logAdapter.Adapt(new Log
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
