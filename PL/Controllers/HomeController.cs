using AutoMapper;
using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public HomeController(IUserService userService,
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
            return View();
        }
    }
}
