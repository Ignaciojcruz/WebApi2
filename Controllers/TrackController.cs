using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class TrackController : ApiController
    {
        // GET: api/Track
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Track track = new Track();
            track.Id = 0;

            return Request.CreateResponse(HttpStatusCode.OK, track.Get_Track());

        }

        // GET: api/Track/5
        public HttpResponseMessage Get(int id)
        {
            Track track = new Track();
            track.Id = id;

            return Request.CreateResponse(HttpStatusCode.OK, track.Get_Track(id));
        }

        // POST: api/Track
        public HttpResponseMessage Post(Track track)
        {
            Track track1 = new Track();
            int resp;

            if(track.IsDeleted)
            {
                //eliminar
                resp = track1.Delete_Track(track.Id);
            }
            else
            {
                resp = track1.Set_Track(track);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // PUT: api/Track/5
        public HttpResponseMessage Put(Track track)
        {
            Track track1 = new Track();
            int resp = track1.Set_Track(track);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
                
    }
}
