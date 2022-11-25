using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class TrackTimeController : ApiController
    {
        // GET: api/TrackTime
        [HttpGet]
        public HttpResponseMessage Get()
        {
            TrackTime trackTime = new TrackTime();
            trackTime.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, trackTime.Get_TrackTime());

        }

        // GET: api/TrackTime/5

        public HttpResponseMessage Get(int id)
        {
            TrackTime trackTime = new TrackTime();
            trackTime.Id = id;

            return Request.CreateResponse(HttpStatusCode.OK, trackTime.Get_TrackTime(id));
        }

        // POST: api/TrackTime
        public HttpResponseMessage Post(TrackTime trackTime)
        {
            TrackTime trackTime1 = new TrackTime();
            int resp;

            if(trackTime.IsDeleted)
            {
                //eliminar
                resp = trackTime1.Delete_TrackTime(trackTime.Id);
            }
            else
            {
                //insertar-actualizar
                resp = trackTime1.Set_TrackTime(trackTime);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // PUT: api/TrackTime/5
        public HttpResponseMessage Put(TrackTime trackTime)
        {
            TrackTime trackTime1 = new TrackTime();
            int resp = trackTime1.Set_TrackTime(trackTime);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

       
    }
}