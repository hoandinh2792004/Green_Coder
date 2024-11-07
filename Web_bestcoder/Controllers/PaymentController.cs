using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Web_bestcoder.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(OrderData orderData)
        //{
        //    // Đường dẫn tới tệp JSON (cần điều chỉnh đường dẫn này tùy thuộc vào cấu trúc dự án của bạn)
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "payment.json");

        //    // Đọc nội dung hiện có của tệp JSON (nếu có)
        //    var existingData = new List<OrderData>();
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        var json = System.IO.File.ReadAllText(filePath);
        //        existingData = JsonConvert.DeserializeObject<List<OrderData>>(json) ?? new List<OrderData>();
        //    }

        //    // Thêm thông tin đặt hàng mới vào danh sách
        //    existingData.Add(orderData);

        //    // Ghi danh sách cập nhật vào tệp JSON
        //    var updatedJson = JsonConvert.SerializeObject(existingData, Formatting.Indented);
        //    System.IO.File.WriteAllText(filePath, updatedJson);

        //    // Trả về view với thông báo thành công (hoặc chuyển hướng nếu cần)
        //    ViewBag.Message = "Đặt hàng thành công!";
        //    return View();
        //}
    }

    public class OrderData
    {
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CartItem
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
