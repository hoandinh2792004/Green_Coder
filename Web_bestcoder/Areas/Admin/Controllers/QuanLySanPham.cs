using Microsoft.AspNetCore.Mvc;

namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class QuanLySanPham : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
