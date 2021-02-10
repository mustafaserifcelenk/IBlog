using IBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IBlog.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            Person person = new Person
            {
                Id = 1,
                Name = "BilgeAdam"
            };
            return Json(person);
        }
    }
}
