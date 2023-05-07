using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;

namespace PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IAccountService accountService, IMapper mapper)
        {
            _userService = userService;
            _accountService = accountService;
            _mapper = mapper;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userModel = _mapper.Map<UserModel>(model);
                var result = await _userService.AddAsync(userModel, model.Password);
                if (result.Succeeded)
                {
                    await _accountService.SignInAsync(userModel, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            returnUrl ??= Url.Content("~/");

            var result = await _accountService.SignInAsync(model.UserName, model.Password, model.RememberMe);

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
