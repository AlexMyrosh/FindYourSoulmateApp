using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
                var userCards = await _userService.GetOtherUsersWithDetailsAsync(currentUser.Id);
                var viewModel = _mapper.Map<List<UserViewModel>>(userCards);
                return View(viewModel);
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
