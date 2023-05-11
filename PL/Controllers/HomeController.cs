using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }
    }
}
