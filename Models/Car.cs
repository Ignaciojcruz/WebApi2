﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.DAL;

namespace WebApi2.Models
{
    public class Car
    {
        public int Id { get; set; }                
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }

        public List<Car> Get_Car()
        {
            CarDAL carDAL = new CarDAL();
            return carDAL.Get_Car(this);
        }

        public int Set_Car(Car car)
        {
            CarDAL carDAL = new CarDAL();
            return carDAL.Set_Car(car); 
        }

        public int Delete_Car(int id)
        {
            CarDAL carDAL = new CarDAL();
            return carDAL.Delete_Car(id);
        }
    }
}