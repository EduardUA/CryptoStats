using CryptoStats.Models.Account;
using CryptoStats.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CryptoStats.Controllers.Identity
{
    public class IdentityController : Controller
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IdentityController(ILogger<IdentityController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {            
            return View(new LoginViewModel { ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user?.UserName ?? String.Empty, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {                    
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login and (or) password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {            
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = userModel.Email,
                    UserName = userModel.Name,
                    DateTimeCreated = DateTime.Now
                };
                var resultAdd = await _userManager.CreateAsync(user, userModel.Password);
                if (resultAdd.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in resultAdd.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(userModel);
        }
    }
}
