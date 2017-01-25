using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Models;

namespace WebApplication4.Controllers {
    using EF6;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        private EF6Repo Repo = new EF6Repo();

        // GET: api/Values
        public IHttpActionResult Get()
        {
            return Ok(Repo.Values.Select(x => x.StringValue));
        }

        // GET: api/Values/5
        public IHttpActionResult Get(int id)
        {
            Value v = Repo.Values.Where(x => x.Id == id).SingleOrDefault();
            if (v == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(v.StringValue);
        }

        // POST: api/Values
        public IHttpActionResult Post([FromBody]string value)
        {
            Value v = new Value() {
                StringValue = value
            };
            Repo.Values.Add(v);
            Repo.SaveChanges();
            return Ok(v);
        }

        // PUT: api/Values/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            Value v = Repo.Values.Where(x => x.Id == id).SingleOrDefault();
            if (v == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            v.StringValue = value;
            Repo.SaveChanges();
            return Ok(v);
        }

        // DELETE: api/Values/5
        public IHttpActionResult Delete(int id)
        {
            Value v = Repo.Values.Where(x => x.Id == id).SingleOrDefault();
            if (v == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Repo.Values.Remove(v);
            Repo.SaveChanges();
            return Ok();
        }
    }
}
