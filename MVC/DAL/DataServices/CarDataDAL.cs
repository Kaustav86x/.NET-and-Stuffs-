﻿using BOL.DataBaseEntities;
using DAL.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class CarDataDAL : ICarDataDAL
    {
        private readonly IDapperORM _dapperORM;
        public CarDataDAL(IDapperORM dapperORM)
        {
            _dapperORM = dapperORM;
        }
        // fucntion with a database communication
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
