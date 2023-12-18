using Microsoft.AspNetCore.Mvc;
using RentaCar.Data;
using RentaCar.Models.Domain;
using RentaCar.Models.ViewModel;
using RentaCarBLL;

namespace RentaCar.Controllers
{
    public class CarController : Controller
    {
        /*private readonly CarDbContext carDbContext;*/
        private RentaCarBLL.CarBLL _cBLL;
        // Ui will interact with BLL only and not the DbContext directly
        /*public CarController(CarDbContext carDbContext)
        {
            this.carDbContext = carDbContext;
        }*/
        public CarController() 
        {
            _cBLL = new RentaCarBLL.CarBLL();
        }
        /*[HttpGet]
        public IActionResult Add()
        {
            return View();
        }*/
        [HttpPost]
        [ActionName("Add")]
        // the Get.cshtml file content would come as an input (acar) to this method
        public IActionResult AddCar() 
        {
            /*if (acar.Kms == null || acar.Type == null || acar.Name == null || acar.Description == null || acar.Rating == null)
            {
                carDbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                var car = new Car
                {
                    Name = acar.Name,
                    Type = acar.Type,
                    Kms = acar.Kms,
                    Rating = acar.Rating,
                    Description = acar.Description,
                };
                carDbContext.Cars.Add(car);
                carDbContext.SaveChanges();
                *//*var name = acar.Name;
                var type = acar.Type;
                var kms = acar.Kms;
                var rating = acar.Rating;
                var desc = acar.Description;*/
            return _cBLL.AddCar()
                /*return View();*/
            }
        }
        /*[HttpGet]
        [ActionName("Carlist")]
        public IActionResult CarList()
        {
            var cars = carDbContext.Cars.ToList();
            return View(cars);
        }*/
    }
}
