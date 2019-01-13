using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TestShopServiceRest.Contexts;
using TestShopServiceRest.Models;

namespace TestShopServiceRest.Controllers
{
    [Route("shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        // GET shop/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            string info = null;
            using (ApplicationContext _db = new ApplicationContext())
            {
                var purchases = _db.Purchases.ToList();
                
                foreach (Purchase p in purchases)
                {
                    info += $"{p.ID}.sum.{p.purchaseSum}.shop.{p.shopID}.user.{p.userID}\n";
                }
            }
            return info ?? "Error";
        }

        // GET shop/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Get page with parametrs " + id;
        }

        // POST shop/values
        [HttpPost]
        public void Post([FromQuery] int id, decimal sum)
        {
            
            using (ApplicationContext _db = new ApplicationContext())
            {
                _db.Purchases.Add(
                    new Purchase
                    {
                        userID = id,
                        purchaseSum = sum
                    }
                );
                _db.SaveChanges();
            }
            var request = (HttpWebRequest)WebRequest.Create($"https://localhost:44389/user?id={id}&sum={sum}");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        // PUT shop/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE shop/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
