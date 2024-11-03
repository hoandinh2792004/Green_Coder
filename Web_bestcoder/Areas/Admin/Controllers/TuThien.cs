using Microsoft.AspNetCore.Mvc;

namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TuThien : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Add()
        {
            return View();
        }
    }
}
