using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    public class TrackTimeController : ApiController
    {
        // GET: api/TrackTime
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TrackTime/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TrackTime
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TrackTime/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TrackTime/5
        public void Delete(int id)
        {
        }
    }
}
