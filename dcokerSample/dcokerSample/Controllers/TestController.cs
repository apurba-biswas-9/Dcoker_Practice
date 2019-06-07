using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dcokerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController :   ControllerBase
    {
        private readonly Entities.MyDBContext _context;
         public TestController(Entities.MyDBContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_context.TestTable.ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _context.TestTable.Add(new Entities.TestTable() { Name = value });
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
