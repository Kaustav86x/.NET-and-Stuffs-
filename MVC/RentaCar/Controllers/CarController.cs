using Microsoft.AspNetCore.Mvc;

namespace RentaCar.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index() 
        { 
            return View();
        }
    }
}
