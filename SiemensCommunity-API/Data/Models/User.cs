using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int OfficeFloor { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<FavoriteProduct> FavoriteProduct { get; set; }
    }
}
