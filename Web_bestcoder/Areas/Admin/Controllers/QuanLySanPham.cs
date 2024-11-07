using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Web_bestcoder.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuanLySanPhamController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static List<Products> products = new List<Products>();

        // Dictionaries to map category and supplier IDs to names
        private readonly Dictionary<int, string> _categoryNames = new Dictionary<int, string>
        {
            { 1, "Bàn ăn" },
            { 2, "Bàn thông minh" },
            { 3, "Tủ" },
            { 4, "Ghế gỗ" },
            { 5, "Ghế sắt" },
            { 6, "Giường người lớn" },
            { 7, "Giường trẻ em" },
            { 8, "Bàn trang điểm" },
            { 9, "Giá đỡ" }
        };

        private readonly Dictionary<int, string> _supplierNames = new Dictionary<int, string>
        {
            { 1, "Phong vũ" },
            { 2, "Thế giới di động" },
            { 3, "FPT" },
            { 4, "Võ Trường" }
        };

        // Constructor to get the web hosting environment
        public QuanLySanPhamController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            LoadProductsFromFile("Areas/Admin/Data/product.json");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult ThemSanPham()
        {
            // Pass category and supplier names to the view using ViewBag
            ViewBag.Categories = _categoryNames;
            ViewBag.Suppliers = _supplierNames;

            return View();
        }

        [HttpPost]
        public IActionResult Products(Products product, IFormFile? Image)
        {
            if (products.Any(p => p.Id == product.Id))
            {
                ModelState.AddModelError("Id", "Product ID already exists.");
                return View("ThemSanPham", product);
            }

            if (Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(fileStream);
                    }
                    product.Image = "/images/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ImageUpload", "Error uploading image: " + ex.Message);
                    return View("ThemSanPham", product);
                }
            }

            products.Add(product);
            SaveProductsToFile("Areas/Admin/Data/product.json");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var productToRemove = products.FirstOrDefault(p => p.Id == Id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                SaveProductsToFile("Areas/Admin/Data/product.json");
            }
            return RedirectToAction("Index");
        }

        private void LoadProductsFromFile(string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                string readText = System.IO.File.ReadAllText(filename);
                var loadedProducts = JsonSerializer.Deserialize<List<Products>>(readText);
                if (loadedProducts != null)
                {
                    products = loadedProducts;
                }
            }
        }

        private void SaveProductsToFile(string filename)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(products, options);

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving products to file: " + ex.Message);
            }
        }
    }
}
