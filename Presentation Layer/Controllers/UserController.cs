using AutoMapper;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.Constants;
using Presentation_Layer.ViewModels;
using System;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;

namespace Presentation_Layer.Controllers
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
            return View(currentUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
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
