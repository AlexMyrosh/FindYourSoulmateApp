using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            try
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
            catch
            {
                return View("Error");
            }
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
            try
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
                // Maybe go through list of errors like in register method?
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);

            }
            catch
            {
                return View("Error");
            }
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _accountService.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProfileView()
        {
            try
            {
                var userModel = await _userService.GetCurrentUserWithDetailsAsync(User);
                if (userModel == null)
                {
                    return NotFound("User not found.");
                }

                var userViewModel = _mapper.Map<UserViewModel>(userModel);
                return View(userViewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProfileUpdate()
        {
            try
            {
                var userModel = await _userService.GetCurrentUserWithDetailsAsync(User);
                if (userModel == null)
                {
                    return NotFound("User not found.");
                }

                var viewModel = new UpdateUserViewModel
                {
                    UserData = _mapper.Map<UserViewModel>(userModel),
                };
                var interestModels = await _interestService.GetAllAsync();
                viewModel.UserData.Interests = _mapper.Map<List<InterestViewModel>>(interestModels);

                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProfileUpdate(UpdateUserViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var interestModels = await _interestService.GetAllAsync();
                    viewModel.UserData.Interests = _mapper.Map<List<InterestViewModel>>(interestModels);
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
                return RedirectToAction("ProfileView");
            }
            catch
            {
                return View("Error");
            }
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
            try
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
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Account/Profile/{userId}")]
        public async Task<IActionResult> UserProfileById(string userId)
        {
            try
            {
                var userModel = await _userService.GetByIdWithDetailsAsync(userId);
                if (userModel == null)
                {
                    return NotFound("User not found.");
                }

                var userViewModel = _mapper.Map<UserViewModel>(userModel);
                return View(userViewModel);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
