using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class CarController : ApiController
    {
        // GET: api/Car
        [HttpGet]
        public HttpResponseMessage Get()
        {                                                
            Car car = new Car();
            car.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, car.Get_Car());
                                    
        }

        // GET: api/Car/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Car car = new Car();
            
            return Request.CreateResponse(HttpStatusCode.OK, car.Get_Car(id));
        }

        // POST: api/Car
        public HttpResponseMessage Post(Car car)
        {
            Car car1 = new Car();
            int resp = 0;

            if(car.IsDeleted == true)
            {
                //eliminar
                resp = car1.Delete_Car(car.Id);
            }
            else
            {
                //ingresar-actualizar
                resp = car1.Set_Car(car);
            }
                        
            return new HttpResponseMessage(HttpStatusCode.OK);
                        
        }

        // PUT: api/Car/5
        public HttpResponseMessage Put(Car car)
        {
            Car car1 = new Car();
            int resp = car1.Set_Car(car);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
                
    }
}
