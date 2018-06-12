using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAdminAndUser.Models;

namespace TestAdminAndUser.AuthSetup
{
    public class AuthInitialize
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public async void SetupDefaultUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            // Create admin user if required.
            var adminUserTest = userManager.FindByName("admin@mysite.com");
            if(adminUserTest == null)
            {
                var newAdminUser = new ApplicationUser { UserName = "admin@mysite.com", Email = "admin@mysite.com" };

                // should be async
                var result = await userManager.CreateAsync(newAdminUser, "Mysite1!");
                if (result.Succeeded)
                {
                    // Need roles for admin and standard user
                    var authHelper = new AuthHelper();
                    authHelper.CreateRoleIfRequired("Admin");
                    authHelper.CreateRoleIfRequired("User");

                    // Add the admin user to the admin role
                    userManager.AddToRole(newAdminUser.Id, "Admin");
                }
            }

            // Create a standard user if required.
            var standardUserTest = userManager.FindByName("user@mysite.com");
            if (standardUserTest == null)
            {
                var newStandardUser = new ApplicationUser { UserName = "user@mysite.com", Email = "user@mysite.com" };

                // should be async
                var result = await userManager.CreateAsync(newStandardUser, "Mysite1!");
                if (result.Succeeded)
                {
                    // Add the admin user to the admin role
                    userManager.AddToRole(newStandardUser.Id, "User");
                }
            }
            _context.SaveChanges();
        }

        
    }
}