using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_bestcoder.Models;

namespace Web_bestcoder.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private List<Product> products = new List<Product>
        {
             new Product { Name = "Bình giữ nhiệt", Price = 149000, ImageUrl = "/User/images/Binhnuoc/image.png", Rating = "5.0",Category = "Binhnuoc" },
            new Product { Name = "Muỗng bã mía", Price = 59000, ImageUrl = "/User/images/dao,dia/image1.png", Rating = "5.0",Category = "dao" },
            new Product { Name = "Bộ dao, muỗng, nĩa bã mía", Price = 104000, ImageUrl = "/User/images/dao,dia/image5.png", Rating = "5.0",Category = "dao" },
            new Product { Name = "Nĩa bã mía", Price = 59000, ImageUrl = "/User/images/dao,dia/image3.png", Rating = "5.0",Category = "dao" },
            new Product { Name = "Muỗng cà phê", Price = 59000, ImageUrl = "/User/images/dao,dia/image6.png", Rating = "5.0",Category = "dao" },
            new Product { Name = "Dao cà phê", Price = 59000, ImageUrl = "/User/images/dao,dia/image7.png", Rating = "5.0",Category = "dao" },
            new Product { Name = "Bộ dao, muỗng, nĩa gỗ", Price = 54000, ImageUrl = "/User/images/dao,dia/image.png", Rating = "5.0",Category = "dao" },
            new Product { Name = "Hộp bã mía", Price = 250000, ImageUrl = "/User/images/HopDoAn/image1.png", Rating = "5.0",Category = "HopDoAn"},
            new Product { Name = "Hộp bã mía vông", Price = 195000, ImageUrl = "/User/images/HopDoAn/image2.png", Rating = "5.0",Category = "HopDoAn" },
            new Product { Name = "Hộp oval bã mía", Price = 190000, ImageUrl = "/User/images/HopDoAn/image3.png", Rating = "5.0" ,Category = "HopDoAn"},
            new Product { Name = "Ly giấy tráng nước", Price = 100000, ImageUrl = "/User/images/ly/image1.png", Rating = "5.0",Category = "Coc" },
            new Product { Name = "Ly bã mía", Price = 100000, ImageUrl = "/User/images/ly/image2.png", Rating = "5.0",Category = "Coc" },
            new Product { Name = "Ly nắp cà phê", Price = 120000, ImageUrl = "/User/images/ly/image4.png", Rating = "5.0",Category = "Coc" },
            new Product { Name = "Ly nắp phẳng", Price = 100000, ImageUrl = "/User/images/ly/image3.png", Rating = "5.0", Discount = null,Category = "Coc" },
            new Product { Name = "Ống Hút Bã Mía", Price = 59000, ImageUrl = "/User/images/OngHut/image1.png", Rating = "5.0", Discount = null,Category = "OngHut" },
            new Product { Name = "Ống Hút Cà Phê", Price = 64000, ImageUrl = "/User/images/OngHut/image2.png", Rating = "5.0", Discount = null ,Category = "OngHut"},
            new Product { Name = "Ống Hút Dừa", Price = 59000, ImageUrl = "/User/images/OngHut/image3.png", Rating = "5.0", Discount = "-10%",Category = "OngHut" },
            new Product { Name = "Ống Hút Gạo", Price = 59000, ImageUrl = "/User/images/OngHut/image4.png", Rating = "5.0", Discount = "-10%",Category = "OngHut" },
            new Product { Name = "Ống Hút Cỏ Bàng", Price = 59000, ImageUrl = "/User/images/OngHut/image5.png", Rating = "4.0", Discount = "-10%" ,Category = "OngHut"},
            new Product { Name = "Túi vải thiết kế", ImageUrl = "/User/images/Tui/image1.png", Rating = "5.0", Price = 49000,Category = "Tui" },
            new Product { Name = "Túi tote vải canvas", ImageUrl = "/User/images/Tui/image2.png", Discount = "-10%", Rating = "5.0", Price = 49000,Category = "Tui"  },
            new Product { Name = "Túi vải thiết kế", ImageUrl = "/User/images/Tui/image3.png", Discount = "-10%", Rating = "5.0", Price = 49000,Category = "Tui"  },
            new Product { Name = "Túi vải thiết kế", ImageUrl = "/User/images/Tui/image5.png", Discount = "-10%", Rating = "5.0", Price = 49000,Category = "Tui"  },
        };


        public IActionResult Index()
        {
            var latestProducts = products.OrderByDescending(p => p.Name).Take(6).ToList();
            var saleProducts = products.Where(p => !string.IsNullOrEmpty(p.Discount)).Take(6).ToList();

            ViewBag.LatestProducts = latestProducts;
            ViewBag.SaleProducts = saleProducts;

            return View(products);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        public IActionResult About()
        {
            return View();
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public string Discount { get; set; } // Optional, if there's a discount
            public string Rating { get; set; }
            public string Category { get; set; } // Added to classify the product

        }
    }
}
