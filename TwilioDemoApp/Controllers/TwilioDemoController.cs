using Microsoft.AspNetCore.Mvc;

namespace TwilioDemoApp.Controllers
{
    public class TwilioDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}