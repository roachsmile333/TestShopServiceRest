using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestShopServiceRest.Contexts;
using TestShopServiceRest.Models;

namespace TestShopServiceRest.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public ActionResult<string> Get()
        {
            string info = null;
            using (ApplicationContext _db = new ApplicationContext())
            {
                var users = _db.Users.ToList();

                foreach (User u in users)
                {
                    info += $"{u.ID}.name.{u.Name}.balance.{u.Balance}\n";
                }
            }
            return info ?? "Error";
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "user";
        }

        // POST: api/User
        [HttpPost]
        public ActionResult Post([FromQuery]int id, decimal sum)
        {
            using (ApplicationContext _db = new ApplicationContext())
            {
                var user = _db.Users.Where(x => x.ID == id).First();
                if (user != null)
                {
                    user.Balance = user.Balance - sum + ((sum / 100)*15);
                }
                _db.SaveChanges();
            }
            return Ok();
        }

        // PUT: api/User/5
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
