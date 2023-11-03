﻿using CourierManagementSystem.Areas.Auth.Models;
using CourierManagementSystem.Services.AuthService.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Services.AuthService
{
    public class RoleManager : IRoleManager
    {
        private readonly ApplicationDbContext  _context;
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleManager(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            _context = context;
        }
        public Task<IdentityResult> CreateAsync(ApplicationRoleViewModel model)
        {
            IdentityRole role = new IdentityRole();
            role.Name = model.RoleName;
            return this.roleManager.CreateAsync((role));
        }
        public Task<IdentityResult> DeleteAsync(ApplicationRoleViewModel model)
        {
            IdentityRole role = new IdentityRole();
            role.Name = model.RoleName;
            return this.roleManager.DeleteAsync((role));
        }

        public async Task<List<ApplicationRoleViewModel>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel model = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name,
                };
                lstRole.Add(model);
            }
            return lstRole;
        }

        public async Task<IEnumerable<string>> GetRoleIds(string userName)
        {
            var result = await (from u in _context.Users
                                join r in _context.UserRoles on u.Id equals r.UserId
                                where u.UserName == userName
                                select r.RoleId).ToListAsync();

            return result;
        }
    }
}
