using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using PL.ViewModels;

namespace PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IInterestService _interestService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IAccountService accountService, IInterestService interestService, IMapper mapper)
        {
            _userService = userService;
            _accountService = accountService;
            _interestService = interestService;
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
                userModel.RegistrationDate = DateTime.UtcNow;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProfileView()
        {
            var userModel = await _userService.GetCurrentUserWithDetailsAsync(User);
            if (userModel == null)
            {
                return NotFound("User not found.");
            }

            var userViewModel = _mapper.Map<UserViewModel>(userModel);
            return View(userViewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProfileUpdate()
        {
            var userModel = await _userService.GetCurrentUserWithDetailsAsync(User);
            if (userModel == null)
            {
                return NotFound("User not found.");
            }
            
            var userViewModel = _mapper.Map<UserViewModel>(userModel);
            var interestModels = await _interestService.GetAllAsync();
            userViewModel.Interests = _mapper.Map<List<InterestViewModel>>(interestModels);

            return View(userViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProfileUpdate(UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var interestModels = await _interestService.GetAllAsync();
                viewModel.Interests = _mapper.Map<List<InterestViewModel>>(interestModels);
                return View(viewModel);
            }

            var userModel = await _userService.GetCurrentUserWithDetailsAsync(User);

            if (userModel == null)
            {
                return NotFound("User not found.");
            }

            userModel = _mapper.Map(viewModel, userModel);

            // Save the changes
            await _userService.UpdateAsync(userModel);
            await _userService.UpdateEmail(User, viewModel.Email);
            await _userService.UpdateUsername(User, viewModel.UserName);
            return RedirectToAction("ProfileView");
        }

        // GET: /Account/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userService.GetCurrentUserWithDetailsAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userService.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            await _accountService.RefreshSignInAsync(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
