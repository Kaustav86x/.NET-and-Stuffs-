/*using BOL.DataBaseEntities;*/
/*using DAL.Data.Model;*/
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public interface ICarLogic
    {
        public List<Car> GetCarListLogic(); 
    }
}
