using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
