using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserLoginCredentials
    {
        public string UserName { get; set; }
        public string Password{ get; set; }
        public bool IsPersistent{ get; set; }
    }
}
