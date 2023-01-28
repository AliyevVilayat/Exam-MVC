using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectEBusinessMVC.Areas.EBusinessVAdmin.ViewModels.Account;
using ProjectEBusinessMVC.Core.Entities;

namespace ProjectEBusinessMVC.Areas.EBusinessVAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(RegisterVM registerVM)
        {

            return View();
        }
    }
}
