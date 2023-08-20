using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
    public class MyLastProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
