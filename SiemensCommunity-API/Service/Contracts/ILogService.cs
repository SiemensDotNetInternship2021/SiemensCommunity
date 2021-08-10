using Common;
using Microsoft.Extensions.Logging;
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
    }
}
