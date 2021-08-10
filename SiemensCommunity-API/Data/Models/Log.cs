using Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Log
    {
        public int Id { get; set; }

        public LogLevel LogLevel{ get; set; }

        [ForeignKey("LogEvent")]
        public int LogEvent { get; set; }
        public string LogMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
