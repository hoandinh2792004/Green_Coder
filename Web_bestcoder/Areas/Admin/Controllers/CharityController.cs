using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_bestcoder.Areas.Admin.Models;
using System.IO;

namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CharityController : Controller
    {
        private static List<Charity> charitys = new List<Charity>();

        [HttpPost]
        public IActionResult Charity(Charity charity)
        {
            LoadCharityFromFile("Areas/Admin/Data/charity.json"); // Load data before adding new charity
            charitys.Add(charity);
            SaveStudentsToFile("Areas/Admin/Data/charity.json"); // Save the updated list back to file
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoadCharityFromFile("Areas/Admin/Data/charity.json");
            return View();
        }

        // Corrected this method to return List<Charity> instead of List<CharityController>
        public List<Charity>? LoadCharityFromFile(string filename)
        {
            string readText = System.IO.File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<Charity>>(readText);
        }

        public void SaveStudentsToFile(string filename)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(charitys, options);

            // Ensure the path is correct for file writing
            using (StreamWriter write = new StreamWriter(filename))
            {
                write.WriteLine(jsonString);
            }
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
