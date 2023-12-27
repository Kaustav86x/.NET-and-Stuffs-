/*using BOL.DataBaseEntities;*/
/*using DAL.Data.Model;*/
using DAL.Model;
/*using DAL.DataMapping;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class CarDataDAL : ICarDataDAL
    {
        public List<Car> GetCarListDAL()
        {
            List<Car> cars = new List<Car>();

            try
            {

            }
            catch (Exception ex)
            {
                string messege = ex.Message;
            }
            /*return new List<Car>();*/
            return cars;
        }
    }
}
