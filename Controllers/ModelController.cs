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
    public class ModelController : ApiController
    {
        // GET: api/Model
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Model model = new Model();
            model.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, model.Get_Model());

        }

        // GET: api/Model/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Model model = new Model();

            return Request.CreateResponse(HttpStatusCode.OK, model.Get_Model(id));
        }

        // POST: api/Model
        public HttpResponseMessage Post(Model model)
        {
            Model model1 = new Model();
            int resp;

            if (model.IsDeleted == true)
            {
                //eliminar
                resp = model1.Delete_Model(model.Id);
            }
            else
            {
                //ingresar-actualizar
                resp = model1.Set_Model(model);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // PUT: api/Model/5
        public HttpResponseMessage Put(Model model)
        {
            Model model1 = new Model();
            int resp = model1.Set_Model(model);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
