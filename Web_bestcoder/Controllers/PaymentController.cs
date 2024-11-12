using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [HttpPost]
        public IActionResult SubmitOrder(OrderData orderData)
        {
            if (ModelState.IsValid)
            {
                var orderJson = JsonConvert.SerializeObject(orderData, Formatting.Indented);
                System.IO.File.WriteAllText("orderData.json", orderJson);
                return Json(new { message = "Cảm ơn bạn đã đặt hàng!" });

            }

            // Lấy thông tin lỗi từ ModelState
            var errors = ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();

            // Trả về lỗi chi tiết
            return Json(new { message = "Vui lòng điền đầy đủ thông tin.", errors });
        }

    }

    public class OrderData
    {
        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        public string Address { get; set; }

        // Notes không bắt buộc nữa
        public string Notes { get; set; }

        [Required(ErrorMessage = "Phương thức thanh toán là bắt buộc.")]
        public string PaymentMethod { get; set; }
    }
    public class CartItem
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
