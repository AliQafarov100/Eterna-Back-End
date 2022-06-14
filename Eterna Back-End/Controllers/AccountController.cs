using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.Models;
using Eterna_Back_End.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eterna_Back_End.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signIn;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signIn)
        {
            _userManager = userManager;
            _signIn = signIn;
        }
        public IActionResult Register()
        {
                return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            return RedirectToAction("Index","Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {
            AppUser user = await _userManager.FindByNameAsync(login.Username);

            Microsoft.AspNetCore.Identity.SignInResult result = await _signIn.PasswordSignInAsync(user, login.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            EditUserVM edit = new EditUserVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };

            return View(edit);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(EditUserVM editUser)
        {
            AppUser existedUser = await _userManager.FindByNameAsync(User.Identity.Name);

            EditUserVM editUserVM = new EditUserVM
            {
                FirstName = existedUser.FirstName,
                LastName = existedUser.LastName,
                UserName = existedUser.UserName,
                Email = existedUser.Email
            };

            if (!ModelState.IsValid) return View(editUserVM);

            bool result = editUser.Password == null && editUser.ConfirmPassword == null && editUser.CurrentPassword != null;

            if(editUser.Email == null || editUser.Email != existedUser.Email)
            {
                ModelState.AddModelError("", "Can not changed email address");
                return View(editUserVM);
            }
            if (result)
            {
                existedUser.FirstName = editUser.FirstName;
                existedUser.LastName = editUser.LastName;
                existedUser.UserName = existedUser.UserName;

                await _userManager.UpdateAsync(existedUser);
            }
            else
            {
                existedUser.FirstName = editUser.FirstName;
                existedUser.LastName = editUser.LastName;
                existedUser.UserName = existedUser.UserName;

                IdentityResult editResult = await _userManager.ChangePasswordAsync(existedUser, editUser.CurrentPassword, editUser.Password);
                if (!editResult.Succeeded)
                {
                    foreach(IdentityError error in editResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(editUserVM);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
