using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trainee_MVCApp.Models;
using Trainee_MVCApp.ViewModels;

namespace Trainee_MVCApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {

                AppUser userModel = new AppUser();
                userModel.FirstName = newUserVM.FirstName;
                userModel.LastName = newUserVM.LastName;
                userModel.UserName = newUserVM.UserName;
                userModel.PasswordHash = newUserVM.Password;

                
                IdentityResult result = await UserManager.CreateAsync(userModel, newUserVM.Password);

                if (result.Succeeded)
                {
                    
                    await SignInManager.SignInAsync(userModel, isPersistent: false);

                    return RedirectToAction("Home", "Index");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("", errorItem.Description);  
                    }
                }
            }

            return View(newUserVM);
        }

        public IActionResult Logout()
        {

            SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel UserVM)
        {
            if (ModelState.IsValid)
            {
                
                AppUser userModelFromDb = await UserManager.FindByNameAsync(UserVM.UserName);

                if (userModelFromDb != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(userModelFromDb, UserVM.Password);

                    if (found == true)
                    {
                        
                        await SignInManager.SignInAsync(userModelFromDb, UserVM.RememberMe);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Wrong UserName Or Password!!");  
            return View(UserVM);
        }
    }
}
