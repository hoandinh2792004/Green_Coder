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
            // Tạo danh sách các bài viết
            var charities = new List<BlogPost>
            {
                new BlogPost { Date = 20, Month = "Oct", Title = "[GreenCycle x BTEC] Chương trình thiện nguyện Bắc Sơn – Lạng Sơn", ImageUrl = "/quyengop/img/blog1.webp", Description = "Đâu đó xung quanh chúng ta vẫn còn những mảnh đời bất hạnh, trẻ em dân tộc có hoàn cảnh khó khăn. Hàng năm sinh viên tại BTEC FPT lại tổ chức những hoạt động tình nguyện... " },
                new BlogPost { Date = 11, Month = "Nov", Title = "[GreenCycle x THPT Mỹ Đình] Chuyến tình nguyện Tả Văn - Sa Pa", ImageUrl = "/quyengop/img/blog2.jpg", Description = "GreenCycle đã đồng hành cùng các bạn THPT phân phát quần áo, sách vở đến các bạn nhỏ thiếu may mắn. Chuyến đi đã giúp các bạn có thêm nhiều trải..." },
                new BlogPost { Date = 29, Month = "Nov", Title = "Doanh nghiệp Việt và các hoạt động CSR hỗ trợ sau bão Yagi", ImageUrl = "/quyengop/img/blog6.jpg", Description = "Trong những ngày qua, nhiều tỉnh của miền Bắc Việt Nam đang phải “oằn mình” khắc phục thiệt hại nặng nề từ trận bão Yagi. Trước tình hình đó, cộng đồng doanh nghiệp Việt Nam đã nhanh chóng..." },
                 new BlogPost { Date = 20, Month = "Oct", Title = "[GreenCycle x FPT] Chuyến đi tình nguyện hỗ trợ...", ImageUrl = "/quyengop/img/blog5.jpg", Description = "Các hoạt động CSR của doanh nghiệp Việt sau bão Yagi không chỉ mang lại những giá trị thiết thực cho cộng đồng mà còn có những ý nghĩa sâu sắc..." },
                new BlogPost { Date = 11, Month = "Nov", Title = "THPT Nguyễn Huệ tổ chức thu gom từ thiện vùng cao.", ImageUrl = "/quyengop/img/blog3.jpg", Description = "Các bạn học sinh THPT Nguyễn Huệ đã quyên góp quần áo, sách vở, đồ ăn uống cho các bạn nhỏ vùng cao nhằm chung tay mang..." },
                new BlogPost { Date = 29, Month = "Nov", Title = "Trải nghiệm tour du lịch tình nguyện có thú vị...", ImageUrl = "/quyengop/img/blog4.jpg", Description = "Mục tiêu dự án hướng tới bảo tồn và phát triển bền vững giá trị văn hóa của người dân tộc Lô Lô kết hợp với tình nguyện..." }
            };

            return View(charities);
        }

         // Mô hình bài viết
    public class BlogPost
    {
        public int Date { get; set; }
        public string Month { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
        public class BlogViewModel
        {
            public IEnumerable<BlogController.BlogPost> Posts { get; set; }
            public int PageNumber { get; set; }
            public int TotalPages { get; set; }
        }
    }

}
