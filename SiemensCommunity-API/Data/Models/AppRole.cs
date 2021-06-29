﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Data.Models
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
