using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController: Controller
    {
        public JsonResult Index()
        {
            return Json(new { Id=1, Name = "Waqar"});
        }
    }
}
