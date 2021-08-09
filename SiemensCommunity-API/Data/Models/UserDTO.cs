using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public int OfficeFloor { get; set; }

        public IEnumerable<AppUserRole> Role { get; set; }
    }
}
