using BLL.LogicServices;
using DAL.Model;
/*using BOL.DataBaseEntities;*/
using Microsoft.AspNetCore.Mvc;

namespace SampleNtierArchitecture.Controllers
{
    public class CarController : Controller
    {
        // so that we can access the BLL layer
        private readonly ICarLogic _carLogic;
        public CarController(ICarLogic carLogic)
        {
            this._carLogic = carLogic;
        }
        [HttpGet]
        public IActionResult CarList()
        {
            List<Car> result = new List<Car>();
            // calling the method from the BLL layer, which further calls the method from the DAL layer
            result = _carLogic.GetCarListLogic().ToList();
            // get car list
            return View(result);
        }
    }
}
