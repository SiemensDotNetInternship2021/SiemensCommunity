using Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Log
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public LogLevel LogLevel { get; set; }
        public int LogEvent { get; set; }
        public string LogMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
