using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServerAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private TestContext context;

        public UserController()
        {
            this.context = new TestContext();
        }

        public List<User> Get()
        {
            return this.context.Users.ToList();
        }

        //// GET: api/User/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/User
        public void Post(User user)
        {
            this.context.Users.Remove(this.context.Users.Find(user.ID));
            this.context.SaveChanges();
        }

        //// PUT: api/User/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}
    }
}
