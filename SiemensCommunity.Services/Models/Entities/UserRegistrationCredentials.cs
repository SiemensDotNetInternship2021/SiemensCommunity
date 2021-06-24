using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensCommunity.Services.Models.Entities
{
    public class UserRegistrationCredentials
    {
        [Display(Name = "Username")]
        [Required]
        public string Username { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Department")]
        [Required]
        public string Department { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Office Floor")]
        [Required]
        [Range(0, 20)]
        public int OfficeFloor { get; set; }
    }
}
