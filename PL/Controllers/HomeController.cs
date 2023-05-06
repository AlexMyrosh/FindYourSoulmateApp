using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private MssqlContext _context;
        public HomeController(MssqlContext context)
        {
            _context = context;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
    }
}
