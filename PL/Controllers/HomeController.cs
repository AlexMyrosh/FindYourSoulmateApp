using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
    }
}
