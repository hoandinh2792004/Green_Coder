﻿using Microsoft.AspNetCore.Mvc;

namespace Web_bestcoder.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
