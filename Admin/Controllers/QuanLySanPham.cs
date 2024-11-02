using Admin.Helpers;
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
        public IActionResult ThemSanPham(SanPham SanPham, IFormFile AnhSanPham)
        {
            if (ModelState.IsValid)
            {

                string uniquePoster = UploadFileHelpers.UpLoadFile(AnhSanPham, "images");
                db.SanPhams.Add(SanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(SanPham);
        }
        [Route("Update")]
        [HttpGet]
        public IActionResult Update(int ID) {
           
            return View();
        }
        [Route("Update")]
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