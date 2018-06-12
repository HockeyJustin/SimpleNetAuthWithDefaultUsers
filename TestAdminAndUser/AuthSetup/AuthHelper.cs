using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAdminAndUser.Models;

namespace TestAdminAndUser.AuthSetup
{
    public class AuthHelper
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        internal void CreateRoleIfRequired(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            var roleInDb = roleManager.FindByName(roleName);
            if (roleInDb == null)
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                roleManager.Create(role);
            }
        }
    }
}