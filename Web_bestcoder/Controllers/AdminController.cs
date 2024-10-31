using Microsoft.AspNetCore.Mvc;

namespace Web_bestcoder.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
