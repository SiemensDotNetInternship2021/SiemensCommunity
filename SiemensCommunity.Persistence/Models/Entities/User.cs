using Microsoft.AspNetCore.Identity;

namespace SiemensCommunity.Persistence.Models.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; } 
        public int OfficeFloor { get; set; }
    }
}