using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Models
{
    public class UserRegisterCredentials
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public int OfficeFloor { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
