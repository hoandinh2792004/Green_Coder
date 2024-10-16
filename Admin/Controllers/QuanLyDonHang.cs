using Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class QuanLyDonHang : Controller
    {

        GreenCoderContext db = new GreenCoderContext();
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
