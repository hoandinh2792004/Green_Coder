
using Microsoft.AspNetCore.Mvc;

namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuanLyDonHang : Controller
    {

       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ThemDonHang()
        {
            return View();
        }
    }
}
