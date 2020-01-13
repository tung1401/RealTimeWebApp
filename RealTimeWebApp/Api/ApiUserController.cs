using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealTimeWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        // GET: api/ApiUser
        [HttpGet]
        public IEnumerable<string> Get()
        {

          //  return new PushStreamResult(OnStreamAvailabe, HttpContext.RequestAborted);
              return new string[] { "value1", "value2" };
        }

        // GET: api/ApiUser/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApiUser
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ApiUser/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
