using Microsoft.AspNetCore.Mvc;

namespace ImageProcessing
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
