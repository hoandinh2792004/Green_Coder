using Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class QuanLySanPham : Controller
    {
        GreenCoderContext db = new GreenCoderContext();
        [Route("QuanLySanPham")]
        public IActionResult Index()
        {
            var lstSP = db.SanPhams.ToList();
            return View(lstSP);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(SanPham SanPham)
        {
            if (ModelState.IsValid)
            {
                
                db.SanPhams.Add(SanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(SanPham);
        }

        [HttpGet]
        public IActionResult Update(int ID) {
            var SanPham = db.SanPhams.Find(ID);
            return View(SanPham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }
    }
}
