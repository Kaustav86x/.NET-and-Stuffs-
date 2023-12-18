using BOL.DataBaseEntities;
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
        public List<Car> GetCarListLogic()
        {
            List<Car> result = new List<Car>();
            return result;
        }
    }
}
