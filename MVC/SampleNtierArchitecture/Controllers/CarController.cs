﻿using Microsoft.AspNetCore.Mvc;

namespace SampleNtierArchitecture.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult CarList()
        {
            return View();
        }
    }
}
