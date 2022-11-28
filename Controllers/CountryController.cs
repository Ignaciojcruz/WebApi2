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
    public class CountryController : ApiController
    {
        // GET: api/Country
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Country country = new Country();
            country.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, country.Get_Country());

        }

        // GET: api/Country/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Country country = new Country();

            return Request.CreateResponse(HttpStatusCode.OK, country.Get_Country(id));
        }

        // POST: api/Country
        public HttpResponseMessage Post(Country country)
        {
            Country country1 = new Country();
            int resp;

            if (country.IsDeleted == true)
            {
                //eliminar
                resp = country1.Delete_Country(country.Id);
            }
            else
            {
                //ingresar-actualizar
                resp = country1.Set_Country(country);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // PUT: api/Country/5
        public HttpResponseMessage Put(Country country)
        {
            Country country1 = new Country();
            int resp = country1.Set_Country(country);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
