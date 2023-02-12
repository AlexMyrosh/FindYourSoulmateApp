using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Constants;
using PL.ViewModels;
using BLL.Models;

namespace PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid surveyId)
        {
            var currentUser = await GetCurrentUserAsync();
            currentUser.LastSurveyPass = surveyId;
            currentUser.UniversityYear = 1;
            return View(currentUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            ModelState.Clear();
            var userByEmail = await _userService.GetByEmailAsync(viewModel.Email);
            var userBySocialMediaUsername = await _userService.GetBySocialMediaUsernameAsync(viewModel.TelegramUsername);
            if (userByEmail != null && userByEmail.Id != viewModel.Id)
            {
                ModelState.AddModelError(nameof(viewModel.Email), "Людина з такою поштою вже проходила тестування. Будь ласка зайдіть з того самого пристрою як і раніше");
            }

            if (userBySocialMediaUsername != null && userBySocialMediaUsername.Id != viewModel.Id)
            {
                ModelState.AddModelError(nameof(viewModel.TelegramUsername), "Людина з таким username вже проходила тестування. Будь ласка зайдіть з того самого пристрою як і раніше");
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userModel = _mapper.Map<UserModel>(viewModel);
            await _userService.UpdateAsync(userModel);
            return RedirectToAction("PassSurvey", "Survey", new {id = viewModel.LastSurveyPass });
        }

        private async Task<UserViewModel> GetCurrentUserAsync()
        {
            var currentUserId = GetUserId();
            var userModel = await _userService.GetOrCreateUserByIdAsync(currentUserId);
            return _mapper.Map<UserViewModel>(userModel);
        }

        private Guid GetUserId()
        {
            Guid.TryParse(HttpContext.Items[UserConstants.UserIdCookieKey].ToString(), out var id);
            return id;
        }
    }
}
