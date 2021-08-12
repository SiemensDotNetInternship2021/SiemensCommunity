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
    public class LogLevelService : ILogLevelService
    {
        private readonly ILogLevelRepository _logLevelRepository;
        private readonly LogLevelAdapter _logLevelAdapter = new LogLevelAdapter();

        public LogLevelService(ILogLevelRepository logLevelRepository)
        {
            _logLevelRepository = logLevelRepository;
        }
        public async Task<IEnumerable<LogLevelModel>> GetAsync()
        {
            var result = await _logLevelRepository.GetAsync();
            return _logLevelAdapter.AdaptEnumerable(result);
        }
    }
}
