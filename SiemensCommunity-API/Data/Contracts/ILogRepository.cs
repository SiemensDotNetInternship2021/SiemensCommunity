using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface ILogRepository: IGenericRepository<Log>
    {
        public Task<IEnumerable<LogDTO>> ShowAsync();
        public Task<IEnumerable<LogDTO>> GetLogsByLevelAndEvent(int logLevelId, int logEventId);
        public Task<IEnumerable<LogDTO>> GetByLogEvent(int logEventId);
        public Task<IEnumerable<LogDTO>> GetByLogLevel(int logLevelId);
    }
}
