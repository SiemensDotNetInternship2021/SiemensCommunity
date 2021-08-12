using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ILogLevelService
    {
        public Task<IEnumerable<LogLevelModel>> GetAsync();
    }
}
