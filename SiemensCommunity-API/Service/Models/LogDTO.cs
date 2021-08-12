using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class LogDTO
    {
        public int Id { get; set; }

        public string LogLevel { get; set; }

        public string LogEvent { get; set; }
        public string LogMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
