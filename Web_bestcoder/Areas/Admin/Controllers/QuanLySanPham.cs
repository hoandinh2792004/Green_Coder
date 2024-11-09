using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Web_bestcoder.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Web_bestcoder.Areas.Admin.Helper;

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
            ViewBag.Categories = _categoryNames;
            ViewBag.Suppliers = _supplierNames;
            return View(products);
        }

        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.Categories = _categoryNames;
            ViewBag.Suppliers = _supplierNames;
            return View();
        }

        [HttpPost]
        public IActionResult Products(Products product, IFormFile? Image)
        {
            // Check if the product ID already exists
            if (products.Any(p => p.Id == product.Id))
            {
                ModelState.AddModelError("Id", "Product ID already exists.");
                return View("ThemSanPham", product);
            }

            // Handle image upload if an image file is provided
            if (Image != null)
            {
                string folderName = "images";
                string uploadedFileName = UploadImage.UpLoadFile(Image, folderName);

                // If the upload was successful, set the image path in the product object
                if (!string.IsNullOrEmpty(uploadedFileName))
                {
                    product.ImagePath = Path.Combine("/uploads", folderName, uploadedFileName);
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
