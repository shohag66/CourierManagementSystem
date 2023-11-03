using CourierManagementSystem.Areas.Auth.Models;
using CourierManagementSystem.Services.AuthService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Services.AuthService
{
    public class UserInfoes: IUserInfoes
    {
        private readonly ApplicationDbContext _context;
        public UserInfoes(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AspNetUsersViewModel> GetUserInfoByUser(string userName)

        {
            try
            {
                var result = await (from U in _context.Users
                                    join r in _context.UserRoles on U.Id equals r.UserId
                                    where U.UserName == userName

                                    select new AspNetUsersViewModel
                                    {
                                        aspnetId = U.Id,
                                        UserName = U.UserName,
                                        UserTypeId = (U.userTypeId == null) ? 0 : U.userTypeId,
                                        Email = U.Email,
                                        isActive = (U.isActive == null) ? 0 : U.isActive,
                                        roleName = _context.Roles.Where(x => x.Id == r.RoleId).Select(x => x.Name).FirstOrDefault(),
                                       
                                    }).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<string> GetUserRoleByUserName(string userName)
        {
            var name = "";
            var user = await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            var userRole = await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            if (userRole != null)
            {
                var role = await _context.Roles.Where(x => x.Id == userRole.RoleId).FirstOrDefaultAsync();
                name = role?.Name;
            }
            else { name = "no roles assingn"; }
            return name;
        }

    }
}
