using Web_bestcoder.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Web_bestcoder.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger; // Khai báo logger

        public LoginController(ILogger<LoginController> logger) // Cập nhật constructor
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users users)
        {
            List<Users>? userList = LoadUsersFromFile("Data/users.json");
            var matchedUser = userList?.FirstOrDefault(u => u.UserName == users.UserName && u.Password == users.Password);

            if (matchedUser != null)
            {
                // Determine role based on username or another condition
                string role = matchedUser.UserName == "Admin" ? "Admin" : "User";

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, matchedUser.UserName),
            new Claim("AvatarUrl", GetRandomImage()), // Add random profile image URL as a claim
            new Claim(ClaimTypes.Role, role) // Assign role claim based on user
        };

                var claimsIdentity = new ClaimsIdentity(claims, "YourCookieScheme");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Sign in user with cookie authentication
                await HttpContext.SignInAsync("YourCookieScheme", claimsPrincipal);

                // Redirect based on role
                if (role == "Admin")
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" }); // Redirect to Admin dashboard
                }
                else
                {
                    return RedirectToAction("Index", "Home"); // Redirect to Home for regular users
                }
            }
            else
            {
                ViewBag.error = "Invalid username or password!";
                return View("Login");
            }
        }

        // Method to get a random profile image URL
        private string GetRandomImage()
        {
            string[] images = { "/img/avatar1.png", "/img/avatar2.png", "/img/avatar3.png" };
            int randomIndex = new Random().Next(images.Length);
            return images[randomIndex];
        }



        // Phương thức tải danh sách người dùng từ file JSON
        public List<Users>? LoadUsersFromFile(string fileName)
        {
            string readText = System.IO.File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Users>>(readText);
        }


        [HttpGet]
        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forgot(string email)
        {
            _logger.LogInformation($"Received email: {email}"); // Log the received email

            if (string.IsNullOrEmpty(email))
            {
                // Add error if email is not provided
                ModelState.AddModelError("Email", "Email không được để trống.");
                return View(); // Return the view with the error message
            }

            // Load the user list from JSON
            var userList = LoadUsersFromFile("Data/users.json");

            // Find the user with the provided email
            var user = userList?.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                // Add error if no user is found with the provided email
                ModelState.AddModelError("Email", "Địa chỉ email không tồn tại trong hệ thống của chúng tôi.");
                return View(); // Return the view with the error message
            }

            // Generate a reset link
            var token = Guid.NewGuid().ToString(); // Generate a token
            var resetLink = Url.Action("ResetPassword", "Login", new { token, email }, Request.Scheme);

            // Add the reset link to the ViewBag
            ViewBag.ResetLink = resetLink;

            // Success message
            ViewBag.Message = "Chúng tôi đã tạo một liên kết đặt lại mật khẩu. Đây là liên kết:";
            return View(); // Return the view with the success message
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                // Thông báo lỗi nếu không có token hoặc email
                ModelState.AddModelError("", "Không tìm thấy thông tin cần thiết để đặt lại mật khẩu.");
                return View(); // Trả về view hiện tại với thông báo lỗi
            }

            // Bạn có thể thêm logic kiểm tra token ở đây nếu cần

            // Trả về view để người dùng nhập mật khẩu mới
            return View(new ResetPasswordModel { Email = email, Token = token });
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // Tải danh sách người dùng từ file JSON
                var userList = LoadUsersFromFile("Data/users.json");

                // Kiểm tra xem người dùng có tồn tại không
                var user = userList?.FirstOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    // Cập nhật mật khẩu cho người dùng
                    user.Password = model.NewPassword;

                    // Lưu lại danh sách người dùng vào tệp JSON
                    SaveUsersToFile("Data/users.json", userList);

                    // Thông báo thành công
                    ViewBag.Message = "Mật khẩu đã được cập nhật thành công!";
                    return RedirectToAction("Login"); // Chuyển hướng về trang đăng nhập
                }
                else
                {
                    ModelState.AddModelError("", "Người dùng không tồn tại.");
                }
            }
            return View(model); // Trả về view nếu có lỗi
        }

        // Phương thức lưu danh sách người dùng vào tệp JSON
        private void SaveUsersToFile(string fileName, List<Users> users)
        {
            string json = JsonSerializer.Serialize(users);
            System.IO.File.WriteAllText(fileName, json);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("YourCookieScheme");
            return RedirectToAction("Index", "Home");
        }
    }
}