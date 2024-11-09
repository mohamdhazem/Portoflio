using DepiMvcTask1.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcDay2Task.ViewModel;

namespace DepiMvcTask1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;


        public AccountController(UserManager<IdentityUser> userManager ,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public SignInManager<IdentityUser> SignInManager { get; }

        public IActionResult Register()
        {
            return View("Register");
        }
        public async Task<IActionResult> SaveRegister(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser? result =await userManager.FindByNameAsync(userViewModel.UserName);
                if (result == null)
                {
                    IdentityUser user = new IdentityUser();
                    user.UserName = userViewModel.UserName;
                    user.PhoneNumber = userViewModel.PhoneNumber;
                    user.PasswordHash = userViewModel.PassWord;
                    var result2 = await userManager.CreateAsync(user, userViewModel.PassWord);
                    if (result2.Succeeded)
                    {
                        
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Project");
                    }
                    foreach (var item in result2.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View("Register");
                }
                ModelState.AddModelError("", "UserName Not Avaliable");
                return View("Register");
            }

            return View("Register",userViewModel);
        }
    }
}
