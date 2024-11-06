using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Web_bestcoder.Areas.Admin.Models;




namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class QuanLySanPhamController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private static List<Products> products = new List<Products>();

        // Constructor to get the web hosting environment
        public QuanLySanPhamController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoadSubjectsFromFile("Areas/Admin/Data/product.json");
            return View(products);
        }

        [HttpGet]
        public IActionResult ThemSanPham()
        {
<<<<<<< HEAD
            var viewModel = new ProductViewModel
            {
                ProductCategories = _context.ProductCategories.ToList(),
                Suppliers = _context.Suppliers.ToList()
                // Removed Product initialization since it's no longer in the view model
            };

            return View(viewModel); // Pass the view model to the view
        }

        // Updated POST: /Admin/QuanLySanPham/ThemSanPham
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public async Task<IActionResult> ThemSanPham(ProductViewModel model) // Change here
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    //ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    SellingPrice = 0, // Default or fetch from somewhere
                    CostPrice = 0, // Default or fetch from somewhere
                    Image = string.Empty, // Default or fetch from somewhere
                    Description = string.Empty, // Default or fetch from somewhere
                    Quantity = 0, // Default or fetch from somewhere
                    Status = "Active", // Changed from boolean to string
                    CategoryId = model.CategoryId, // Assuming CategoryId is part of ProductViewModel
                    SupplierId = model.SupplierId // Assuming SupplierId is part of ProductViewModel
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // If validation fails, reload categories and suppliers
            model.ProductCategories = _context.ProductCategories.ToList();
            model.Suppliers = _context.Suppliers.ToList();

            return View(model); // Pass the updated model back to the view
=======
            return View();
        }

        [HttpPost]
        public IActionResult Products(Products product, IFormFile? Image)
        {
            LoadSubjectsFromFile("Areas/Admin/Data/product.json"); // Load data from file before adding new product

            // Handle image upload if an image is provided
            if (Image != null)
            {
                // Define the path where the image will be saved
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder); // Ensure the directory exists

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save the image file to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }

                // Set the image path in the product object
                product.Image = "/images/" + uniqueFileName;
            }

            products.Add(product); // Add the product to the list
            SaveProductToFile("Areas/Admin/Data/product.json"); // Save the updated list to file
            return RedirectToAction("Index");
>>>>>>> 100091154970fa22928008c1da44670316523a62
        }

        public List<Products>? LoadSubjectsFromFile(string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                string readText = System.IO.File.ReadAllText(filename);
                return JsonSerializer.Deserialize<List<Products>>(readText);
            }
            return new List<Products>();
        }

        public void SaveProductToFile(string filename)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(products, options);

            // Save the updated list to the JSON file
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(jsonString);
            }
        }



        public IActionResult Delete(int Id)
        {
            var product = LoadSubjectsFromFile("Areas/Admin/Data/product.json");
            var searchSubject = product.FirstOrDefault(t => t.Id == Id);
            products.Remove(searchSubject);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter write = new StreamWriter("Areas/Admin/Data/product.json"))
            {
                write.WriteLine(jsonString);
            }
            return RedirectToAction("Index");
        }



        //[HttpGet]
        //public IActionResult SubjectEdit(string Id)
        //{

        //    var subjectToEdit = subjects.FirstOrDefault(s => s.Id == Id);
        //    return View(subjectToEdit);
        //}

        public object Setup(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

    }
}
