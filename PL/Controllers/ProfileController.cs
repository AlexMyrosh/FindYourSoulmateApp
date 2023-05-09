using System.Runtime.InteropServices;
using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Extentions;
using PL.ViewModels;

namespace PL.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfileController(IUserService userService,
            IProfileService profileService,
            IMapper mapper)
        {
            _userService = userService;
            _profileService = profileService;
            _mapper = mapper;
        }

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            try
            {
                // Get the current user
                var currentUser = await _userService.GetCurrentUserWithDetailsAsync(User);

                if (currentUser == null)
                {
                    return NotFound("User not found.");
                }

                // Retrieve the list of user cards
                var model = await GetUsersToShow();
                return View(new UserProfileSelectionViewModel
                {
                    UsersToDisplay = model,
                    CurrentUser = _mapper.Map<UserViewModel>(currentUser)
                });
            }
            catch (ExternalException)
            {
                return View("UsersToShowNotFound");
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task Like(string userId)
        {
            RegisterUserView(userId);
            await _profileService.LikeUser(User, userId);
        }

        [HttpPost]
        public async Task Dislike(string userId)
        {
            RegisterUserView(userId);
        }

        private async Task<List<UserViewModel>> GetUsersToShow()
        {
            // Retrieve the recent views from the session
            var recentViews = HttpContext.Session.GetObject<List<UserView>?>("UserViews") ?? new List<UserView>();
            var oneWeekAgo = DateTime.UtcNow.AddDays(-7);

            // Remove users who were shown less than a week ago
            var viewedUserIds = recentViews
                .Where(uv => uv.ViewDate > oneWeekAgo)
                .Select(uv => uv.ViewerUserId)
                .ToList();

            var usersToShow = await _userService.GetUsersToShow(User);
            usersToShow = usersToShow.Where(u => !viewedUserIds.Contains(u.Id)).ToList();
            var userViewModels = _mapper.Map<List<UserViewModel>>(usersToShow);
            return userViewModels;
        }

        public void RegisterUserView(string viewerUserId)
        {
            var userView = new UserView
            {
                ViewerUserId = viewerUserId,
                ViewDate = DateTime.UtcNow
            };

            var userViews = HttpContext.Session.GetObject<List<UserView>?>("UserViews") ?? new List<UserView>();
            userViews.Add(userView);

            HttpContext.Session.SetObject("UserViews", userViews);
        }
    }
}