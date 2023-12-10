using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentaCar.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
