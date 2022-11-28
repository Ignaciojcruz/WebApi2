
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
    public class TypeController : ApiController
    {
        // GET: api/Type
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Type type = new Type();
            type.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, type.Get_Type());

        }

        // GET: api/Type/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Type type = new Type();

            return Request.CreateResponse(HttpStatusCode.OK, type.Get_Type(id));
        }

        // POST: api/Type
        public HttpResponseMessage Post(Type type)
        {
            Type type1 = new Type();
            int resp;

            if (type.IsDeleted == true)
            {
                //eliminar
                resp = type1.Delete_Type(type.Id);
            }
            else
            {
                //ingresar-actualizar
                resp = type1.Set_Type(type);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // PUT: api/Type/5
        public HttpResponseMessage Put(Type type)
        {
            Type type1 = new Type();
            int resp = type1.Set_Type(type);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
