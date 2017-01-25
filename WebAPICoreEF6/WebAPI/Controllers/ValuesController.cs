using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using EF6;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller {
        private EF6Repo Repo = new EF6Repo();

        // GET api/values
        [HttpGet]
        public IActionResult Get() {
            return Ok(Repo.Values.Select(x => x.StringValue));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            Value v = Repo.Values.Where(x => x.Id == id).FirstOrDefault();
            if (v == null) {
                return NotFound();
            }
            return Ok(v.StringValue);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value) {
            Value v = new Value() {
                StringValue = value
            };
            Repo.Values.Add(v);
            Repo.SaveChanges();
            return Ok(v);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value) {
            Value v = Repo.Values.Where(x => x.Id == id).FirstOrDefault();
            if (v == null) {
                return NotFound();
            }
            v.StringValue = value;
            Repo.SaveChanges();
            return Ok(v);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            Value v = Repo.Values.Where(x => x.Id == id).FirstOrDefault();
            if (v == null) {
                return NotFound();
            }
            Repo.Values.Remove(v);
            Repo.SaveChanges();
            return NoContent();
        }
    }
}
