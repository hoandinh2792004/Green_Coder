using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Web_bestcoder.Data;
using Web_bestcoder.ViewModels;

namespace Web_bestcoder.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly GreenCoderContext _db;

        public AuthenticationController(GreenCoderContext context)
        {
            _db = context;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var passwordHasher = new PasswordHasher<Users>();

                    Users user = new Users
                    {
                        FullName = model.UserName,
                        Email = model.Email,
                        UserName = model.Email,
                        // Only set PasswordHash since ConfirmPassword is removed.
                        PasswordHash = passwordHasher.HashPassword(null, model.Password) // Pass 'null' for the user object
                    };

                    // Remove the line below if Password is not required
                    // user.Password = model.Password; // Only if you need to store the plain password, otherwise remove

                    _db.Users.Add(user);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("Login", "Authentication");
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError("", "An error occurred while connecting to the database.");
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
            }
            return View(model);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.Users
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null)
                {
                    var passwordHasher = new PasswordHasher<Users>();
                    var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                    if (result == PasswordVerificationResult.Success)
                    {
                        // Successful login
                        HttpContext.Session.SetString("UserEmail", user.Email); // Store the user's email or username in the session
                        HttpContext.Session.SetString("UserName", user.FullName); // Store full name or username

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Email or password is incorrect.");
            }

            return View(model);
        }

        #endregion
        public IActionResult Logout()
        {
            // Clear the session data
            HttpContext.Session.Clear();

            // Optionally, sign out of authentication (if using cookie authentication)
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home"); // Redirect to home or login page
        }
        #region VerifyEmail
        public IActionResult VerifyEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Something is wrong!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword", new { username = user.UserName });
                }
            }
            return View(model);
        }


        #endregion

        #region ChangePassword
        public IActionResult ChangePassword(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail", "Authentication");
            }
            return View(new ChangePasswordViewModel { Email = username });
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    var passwordHasher = new PasswordHasher<Users>();
                    var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.OldPassword);

                    if (result == PasswordVerificationResult.Success)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
                        _db.Users.Update(user);
                        await _db.SaveChangesAsync();
                        return RedirectToAction("Login", "Authentication");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Old password is incorrect.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found!");
                }
            }
            return View(model);
        }


        #endregion
    }
}
