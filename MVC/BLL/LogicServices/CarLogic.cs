using BOL.DataBaseEntities;
using DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public class CarLogic : ICarLogic
    {
        // function signature has been initialized in the interface class
        // logic is used as a prefix for the understanding of the method existing in a particular layer (like Bussiness Logic Layer)
        private readonly ICarDataDAL _carDataDAL;
        public CarLogic(ICarDataDAL carDataDAL)
        {
            this._carDataDAL = carDataDAL;
        }
        public List<Car> GetCarListLogic()
        {
            List<Car> result = new List<Car>();

            // a method in DAL will be called from this file ie, BLL
            result = _carDataDAL.GetCarListDAL();   

            // returning to the controller, so go to controller
            return result;
        }
    }
}
