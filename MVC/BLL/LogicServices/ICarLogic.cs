using BOL.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    internal interface ICarLogic
    {
        public List<Car> GetCarListLogic(); 
    }
}
