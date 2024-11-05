using Microsoft.AspNetCore.Mvc;

namespace Web_bestcoder.Controllers
{
    public class ResgisterCharity : Controller
    {
        private readonly IConfiguration _configuration;

        public ResgisterCharity(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            // Pass the Goong API Key to the view

            ViewData["MapKey"] = _configuration["GoongMap:MaptilesKey"];

            return View();
        }
    }
}
