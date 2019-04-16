using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMgmt.Models;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace CustomerMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICapPublisher _capBus;
        private readonly CustomerDbContext _customerDbContext;
        public ValuesController(ICapPublisher capPublisher, CustomerDbContext customerDbContext)
        {
            _capBus = capPublisher; ;
            _customerDbContext = customerDbContext;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            using (var transaction = _customerDbContext.Database.BeginTransaction(_capBus, autoCommit: true))
            {
                CustomerRegistered e = new CustomerRegistered();
                e.Id = 8;
                e.Name = "Santhosh";
                e.MobileNo = "7894563211";
                await _customerDbContext.Customers.AddAsync(e);
                await _customerDbContext.SaveChangesAsync();
                await _capBus.PublishAsync("customer", e);

            }
            return new string[] { "value1", "value2" };
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
