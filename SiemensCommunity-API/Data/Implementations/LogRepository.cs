using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(ProjectDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<LogDTO>> ShowAsync()
        {
            return await Context.Logs
                    .Include(l => l.LogEvent)
                    .Include(l => l.LogLevel)
                    .Select(l => new LogDTO
                    {
                        Id = l.Id,
                        LogEvent = l.LogEvent.Name,
                        LogLevel = l.LogLevel.Name,
                        LogMessage = l.LogMessage,
                        StackTrace = l.StackTrace
                    }).ToListAsync();
        }
        public async Task<IEnumerable<LogDTO>> GetByLogEvent(int logEventId)
        {
            return await Context.Logs.Where(l => l.LogEventId == logEventId)
                .Include(l => l.LogEvent)
                .Include(l => l.LogLevel)
                .Select(l => new LogDTO
                {
                    Id = l.Id,
                    LogEvent = l.LogEvent.Name,
                    LogLevel = l.LogLevel.Name,
                    LogMessage = l.LogMessage,
                    StackTrace = l.StackTrace
                }).ToListAsync();
        }

        public async Task<IEnumerable<LogDTO>> GetByLogLevel(int logLevelId)
        {
            return await Context.Logs.Where(l => l.LogLevelId == logLevelId)
                .Include(l => l.LogEvent)
                .Include(l => l.LogLevel)
                .Select(l => new LogDTO
                {
                    Id = l.Id,
                    LogEvent = l.LogEvent.Name,
                    LogLevel = l.LogLevel.Name,
                    LogMessage = l.LogMessage,
                    StackTrace = l.StackTrace
                }).ToListAsync();
        }

        public async Task<IEnumerable<LogDTO>> GetLogsByLevelAndEvent(int logLevelId, int logEventId)
        {
            return await Context.Logs.Where(l => l.LogLevelId == logLevelId && l.LogEventId == logEventId)
                .Include(l => l.LogEvent)
                .Include(l => l.LogLevel)
                .Select(l => new LogDTO
                {
                    Id = l.Id,
                    LogEvent = l.LogEvent.Name,
                    LogLevel = l.LogLevel.Name,
                    LogMessage = l.LogMessage,
                    StackTrace = l.StackTrace
                }).ToListAsync();
        }
    }
}
