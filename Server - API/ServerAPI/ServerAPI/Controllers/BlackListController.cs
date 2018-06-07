using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerAPI.Models;
using System.Web.Http.Cors;

namespace ServerAPI.Controllers
{

    [Authorize]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BlackListController : ApiController
    {
        private TestContext context = new TestContext();

        // GET: api/BlackList
      

        public List<BlackList> Get()
        {
            return this.context.BlackListed.ToList();
        }


        // POST: api/BlackList
        public void Post(BlackList value)
        {
            this.context.BlackListed.Add(value);
            this.context.SaveChanges();
        }

        // PUT: api/BlackList/5
        public void Put(BlackList value)
        {
            this.context.BlackListed.Remove(this.context.BlackListed.Find(value.ID));
            this.context.SaveChanges();

        }

      
    }
}
