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
        public HttpResponseMessage Get()
        {                                                
            Car car = new Car();
            car.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, car.Get_Car());
                                    
        }

        // GET: api/Car/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Car
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Car/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Car/5
        public void Delete(int id)
        {
        }
    }
}
