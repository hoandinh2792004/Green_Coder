using Microsoft.AspNetCore.Mvc;


namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuanLyKhachHang : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
