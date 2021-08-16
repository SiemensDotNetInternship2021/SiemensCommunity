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
    public class LogEventRepository: GenericRepository<LogEvent>, ILogEventRepository
    {
        public LogEventRepository(ProjectDbContext context): base(context)
        {

        }

        public async Task<int> GetLogEventIdAsync(int logEvent)
        {
            return await Context.LogEvents.Where(l => l.CodeId == logEvent).Select(l => l.Id).SingleOrDefaultAsync();
        }
    }
}
