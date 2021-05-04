using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PraktikaGamma.Models;
using PraktikaGamma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Services
{
    public class AccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager    = userManager;
            _signInManager  = signInManager;
            _roleManager    = roleManager;
        }

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            var result = await _userManager.CreateAsync(new User { UserName = model.UserName}, model.Password);

            return result; 
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginViewModel model)
        {
            await _roleManager.CreateAsync(new IdentityRole("Worker"));

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }
    }
}
