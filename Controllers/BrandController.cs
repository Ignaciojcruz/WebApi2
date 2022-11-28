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
    public class BrandController : ApiController
    {
        // GET: api/Brand
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Brand brand = new Brand();
            brand.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, brand.Get_Brand());

        }

        // GET: api/Brand/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Brand brand = new Brand();

            return Request.CreateResponse(HttpStatusCode.OK, brand.Get_Brand(id));
        }

        // POST: api/Brand
        public HttpResponseMessage Post(Brand brand)
        {
            Brand brand1 = new Brand();
            int resp;

            if (brand.IsDeleted == true)
            {
                //eliminar
                resp = brand1.Delete_Brand(brand.Id);
            }
            else
            {
                //ingresar-actualizar
                resp = brand1.Set_Brand(brand);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // PUT: api/Brand/5
        public HttpResponseMessage Put(Brand brand)
        {
            Brand brand1 = new Brand();
            int resp = brand1.Set_Brand(brand);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}