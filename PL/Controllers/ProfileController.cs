using System.Runtime.InteropServices;
using AutoMapper;
using BLL.Enums;
using BLL.Models;
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
                var model = await GetUserToShow(HttpContext.Session);
                RegisterUserView(model.Id, HttpContext.Session);
                return View(model);
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
        public async Task<IActionResult> Like(string userId)
        {
            try
            {
                var currentUser = await _userService.GetCurrentUserWithDetailsAsync(User);
                await _profileService.LikeUser(currentUser.Id, userId);

                var model = await GetUserToShow(HttpContext.Session);
                RegisterUserView(model.Id, HttpContext.Session);
                return PartialView("PartialViews/_UserProfileCard", model);
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
        public async Task<IActionResult> Dislike(string userId)
        {
            try
            {
                var model = await GetUserToShow(HttpContext.Session);
                RegisterUserView(model.Id, HttpContext.Session);
                return PartialView("PartialViews/_UserProfileCard", model);
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

        private async Task<UserViewModel> GetUserToShow(ISession session)
        {
            var currentUser = await _userService.GetCurrentUserWithDetailsAsync(User);

            // Retrieve the recent views from the session
            var recentViews = session.GetObject<List<UserView>?>("UserViews") ?? new List<UserView>();
            var oneWeekAgo = DateTime.UtcNow.AddDays(-7);

            // Remove users who were shown less than a week ago
            var viewedUserIds = recentViews
                .Where(uv => uv.ViewerUserId == currentUser.Id && uv.ViewDate > oneWeekAgo)
                .Select(uv => uv.ViewerUserId)
                .ToList();

            var matchingProfiles = new List<UserModel>();
            var allProfiles = await _userService.GetAllWithDetailsAsync();
            allProfiles = allProfiles.Where(u => u.Id != currentUser.Id && !viewedUserIds.Contains(u.Id)).ToList();

            var ageFilteredProfiles = allProfiles.Where(profile =>
                profile.Id != currentUser.Id &&
                Math.Abs(currentUser.Age - profile.Age) <= 10
            ).ToList();

            var genderFilteredProfiles = ageFilteredProfiles;
            if (currentUser.LookingForGender != LookingForGenderModel.Both)
            {
                genderFilteredProfiles = ageFilteredProfiles.Where(profile =>
                    currentUser.LookingForGender.ToString() == profile.Gender.ToString() &&
                    profile.LookingForGender.ToString() == currentUser.Gender.ToString()
                ).ToList();
            }

            // Filter based on common interests
            var interestFilteredProfiles = genderFilteredProfiles.Where(profile =>
                currentUser.Interests.Intersect(profile.Interests).Any()
            ).ToList();

            // Add profiles with common RelationType
            var relationTypeFilteredProfiles = interestFilteredProfiles.Where(profile =>
                profile.RelationType == currentUser.RelationType
            ).ToList();

            matchingProfiles.AddRange(relationTypeFilteredProfiles);

            // Add remaining profiles
            matchingProfiles.AddRange(interestFilteredProfiles.Except(relationTypeFilteredProfiles));

            var allUserViewModels = _mapper.Map<List<UserViewModel>>(matchingProfiles);
            if (matchingProfiles.Count == 0)
            {
                throw new ExternalException();
            }

            var randomUserNumber = new Random().Next(0, matchingProfiles.Count - 1);
            return allUserViewModels[randomUserNumber];
        }

        public void RegisterUserView(string viewerUserId, ISession session)
        {
            var userView = new UserView
            {
                ViewerUserId = viewerUserId,
                ViewDate = DateTime.UtcNow
            };

            var userViews = session.GetObject<List<UserView>?>("UserViews") ?? new List<UserView>();
            userViews.Add(userView);

            session.SetObject("UserViews", userViews);
        }
    }
}
