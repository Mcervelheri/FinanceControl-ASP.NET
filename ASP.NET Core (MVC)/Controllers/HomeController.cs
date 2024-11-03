using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core__MVC_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
