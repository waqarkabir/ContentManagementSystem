using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resourse you requested could not be found";
                    break;
            }
            return View("NotFound");
        }
    }
}
