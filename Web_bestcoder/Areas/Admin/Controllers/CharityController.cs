using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_bestcoder.Areas.Admin.Models;
using System.IO;
using System.Linq;

namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CharityController : Controller
    {
        private static List<Charity> charitys = new List<Charity>();

        [HttpPost]
        public IActionResult Charity(Charity charity)
        {
            // Load data from the file before adding new charity
            LoadCharityFromFile("Areas/Admin/Data/charity.json");

            // Generate the next available ID
            int newId = charitys.Any() ? charitys.Max(c => c.Id) + 1 : 1;
            charity.Id = newId;

            // Add the charity with the new ID
            charitys.Add(charity);

            // Save the updated list back to the file
            SaveCharityToFile("Areas/Admin/Data/charity.json");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoadCharityFromFile("Areas/Admin/Data/charity.json");
            return View(charitys);
        }

        // This method loads the charity data from the file
        public List<Charity> LoadCharityFromFile(string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                string readText = System.IO.File.ReadAllText(filename);
                charitys = JsonSerializer.Deserialize<List<Charity>>(readText) ?? new List<Charity>();
            }
            return charitys;
        }

        // This method saves the charity data to the file
        public void SaveCharityToFile(string filename)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(charitys, options);

            // Ensure the path is correct for file writing
            using (StreamWriter write = new StreamWriter(filename))
            {
                write.WriteLine(jsonString);
            }
        }

        // Add action to handle deletion
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Load charity data from file
            LoadCharityFromFile("Areas/Admin/Data/charity.json");

            // Find the charity with the given id
            var charityToDelete = charitys.FirstOrDefault(c => c.Id == id);
            if (charityToDelete != null)
            {
                // Remove the charity from the list
                charitys.Remove(charityToDelete);

                // Save the updated list to the file
                SaveCharityToFile("Areas/Admin/Data/charity.json");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
