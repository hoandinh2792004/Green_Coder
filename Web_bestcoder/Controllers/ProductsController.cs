using Microsoft.AspNetCore.Mvc;

namespace Web_bestcoder.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
    }
}
