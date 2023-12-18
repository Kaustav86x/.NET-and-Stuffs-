using BOL.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class CarDataDAL : ICarDataDAL
    {
        // fucntion with a database communication
        public List<Car> GetCarListDAL()
        {
            return new List<Car>();
        }
    }
}
