using Data.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class UserRepository : GenericRepository<UserDTO>, IUserRepository
    {
        private RoleManager<AppRole> _roleManager;
        private UserManager<User> _userManager;
        public UserRepository(ProjectDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<UserDTO>> GetAsync()
        {
            var user = Context.Users.Include(u => u.UserRoles)
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Department = x.Department,
                OfficeFloor = x.OfficeFloor,
                FirstName = x.FirstName,
                LastName = x.LastName,
                //Role = x.UserRoles.Where(ur => ur.Role.Id == x.Id)
            }).ToListAsync();

            return await user;
        }
    }
}
