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
    public class LogLevelRepository : GenericRepository<LogLevel>, ILogLevelRepository
    {
        public LogLevelRepository(ProjectDbContext context): base(context)
        {

        }

        public async Task<int> GetLogLevelIdAsync(string logLevel)
        {
            return await Context.LogLevels.Where(l => l.Name == logLevel).Select(l => l.Id).SingleOrDefaultAsync();
        }
    }
}
