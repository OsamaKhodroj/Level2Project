using Microsoft.AspNetCore.Mvc;

namespace Level2Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
