using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimulationMVC1.Migrations;
using SimulationMVC1.ViewModels.Account;

namespace SimulationMVC1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager,RoleManager<IdentityRole>roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult>Register(RegisterVM userVM)
        //{
        //    if (!ModelState.IsValid) return View();

        //    AppUser user=new AppUser
        //    {
        //        Name=userVM.Name,
        //        Surname=userVM.Surname,
        //        Email=userVM.Email,
        //        UserName=userVM.UserName

        //    }

        //}
    }
}
