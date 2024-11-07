using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_bestcoder.Areas.Admin.Models;

namespace Web_bestcoder.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private static List<Products> products = new List<Products>();

        // Constructor to get the web hosting environment
        public ProductsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            LoadProductsFromFile("Areas/Admin/Data/product.json");
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

        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Payment()
        {
            return View();
        }
    }
}
