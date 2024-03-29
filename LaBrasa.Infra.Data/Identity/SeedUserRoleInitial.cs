﻿using LaBrasa.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBrasa.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager,
              UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@gmail").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@gmail.com";
                user.Email = "usuario@gmail.com";
                user.PhoneNumber = "21975518858";  
                user.NormalizedUserName = "USUARIO@GMAIL.COM";
                user.NormalizedEmail = "USUARIO@GMAIL.COM";
                user.PhoneNumberConfirmed = true; 
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#2022").Result;

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }

            if (_userManager.FindByEmailAsync("admin@local").Result == null)
            { 
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@local.com.br";
                user.Email = "admin@local.com.br";
                user.PhoneNumber = "21975518853"; 
                user.NormalizedUserName = "admin@local.com.br";
                user.NormalizedEmail = "ADMIN@LOCAL.COM.BR";
                user.PhoneNumberConfirmed = true; 
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#2022").Result;

                if (result.Succeeded)
                {
                   await _userManager.AddToRoleAsync(user, "Admin");
                }
            }

        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}

