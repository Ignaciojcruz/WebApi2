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
        
        public HttpResponseMessage Get(int id)
        {
            Car car = new Car();
            car.Id = id;

            return Request.CreateResponse(HttpStatusCode.OK, car.Get_Car());
        }

        // POST: api/Car
        public HttpResponseMessage Post(Car car)
        {
            Car car1 = new Car();
            int resp = car1.Set_Car(car);

            return new HttpResponseMessage(HttpStatusCode.OK);
                        
        }

        // PUT: api/Car/5
        public HttpResponseMessage Put(Car car)
        {
            Car car1 = new Car();
            int resp = car1.Set_Car(car);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE: api/Car/5
        [HttpDelete]
        [Route("api/Car/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            Car car = new Car();
            car.Id = id;

            int resp = car.Delete_Car(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
