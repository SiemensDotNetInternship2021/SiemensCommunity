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
        private UserManager<User> _userManager;
        private RoleManager<AppRole> _roleManager;
        public UserRepository(ProjectDbContext context, UserManager<User> userManager, RoleManager<AppRole> roleManager) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;


        }

        public override async Task<IEnumerable<UserDTO>> GetAsync()
        {
            var user = Context.Users
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    Department = x.Department,
                    OfficeFloor = x.OfficeFloor,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Roles = x.UserRoles.Select(ur => ur.Role.Name).ToList()
                }).ToListAsync();

            return await user;
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = Context.Users.Where(u => u.Id == userId)
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Department = x.Department,
                    OfficeFloor = x.OfficeFloor,
                    Roles = x.UserRoles.Select(ur => ur.Role.Name).ToList(),
                }).SingleOrDefaultAsync();
            return await user;
        }

        public async Task<IEnumerable<string>> GetRoles()
        {
            var roles = Context.Roles.Select(ur => ur.Name).ToListAsync();
            return await roles;
        }


        public async Task<UserDTO> UpdateUser(UserDTO userDetails)
        {

            var existing = Context.Users.Find(userDetails.Id);
            Context.Entry(existing).CurrentValues.SetValues(userDetails);

            var userRoles = await _userManager.GetRolesAsync(existing);
            if(userRoles.Count() <= 0)
            {
                foreach (var role in userDetails.Roles)
                {
                    await _userManager.AddToRoleAsync(existing, role);
                    await Context.SaveChangesAsync();
                }
            }
            else
            {
                foreach (var role in userDetails.Roles)
                {
                    if (!userRoles.Contains(role))
                    {
                        await _userManager.AddToRoleAsync(existing, role);
                    }
                    if (userRoles.Contains(role))
                    {
                        await _userManager.RemoveFromRoleAsync(existing, role);
                    }
                    await Context.SaveChangesAsync();
                }
            }
            return userDetails;
        }
    }
}

