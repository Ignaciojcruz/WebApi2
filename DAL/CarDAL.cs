using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.Models;
using ConectaBD;

namespace WebApi2.DAL
{
    public class CarDAL
    {
        //conectar a BBDD


        //guardar datos
        public int Insert_Car(Car car)
        {
            int resp = 0;

            Conecta conecta = new Conecta();

            
            

            return resp;
        }


        //retornar datos
        public Car Get_Car(int id)
        {
            Car car = new Car();

            return car;
        }


        //actualizar datos
        public int Update_Car(Car car)
        {
            int resp = 0;



            return resp;
        }


        //eliminar datos
        public int Delete_Car(Car car)
        {
            int resp = 0;



            return resp;
        }
    }
}