using Common;
using Microsoft.Extensions.Logging;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ILogService
    {
        public Task<bool> SaveAsync(LogLevel logLevel, int logEvent, string message, string stackTrace);
        public Task<IEnumerable<LogDTO>> GetAsync();
        public Task<IEnumerable<LogDTO>> GetLogsByLevelAndEvent(int logLevelId, int logEventId);
        public Task<IEnumerable<LogDTO>> GetByLogEvent(int logEventId);
        public Task<IEnumerable<LogDTO>> GetByLogLevel(int logLevelId);
    }
}
