using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_bestcoder.Areas.Admin.Models;

namespace Web_bestcoder.Controllers
{
    public class BlogController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private static List<Charity> charities = new List<Charity>();

        // Constructor to get the web hosting environment
        public BlogController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            LoadProductsFromFile("Areas/Admin/Data/charity.json");
        }

        private void LoadProductsFromFile(string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                string readText = System.IO.File.ReadAllText(filename);
                var loadedCharity = JsonSerializer.Deserialize<List<Charity>>(readText);
                if (loadedCharity != null)
                {
                    charities = loadedCharity;
                }
            }
        }

        public IActionResult Index()
        {
            return View(charities);
        }
    }
}
