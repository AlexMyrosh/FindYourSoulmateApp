using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
                    break;
                // You can handle other HTTP status codes if needed.
                //case 500:
                //    ViewBag.ErrorMessage = "Something went wrong on the server.";
                //    break;
            }
            return View("StatusCodePage");
        }
    }
}
