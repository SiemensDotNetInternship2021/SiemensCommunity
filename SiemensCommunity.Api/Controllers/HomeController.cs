using Microsoft.AspNetCore.Mvc;

namespace SiemensCommunity.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
