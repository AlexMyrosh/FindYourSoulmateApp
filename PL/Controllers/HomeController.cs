using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
