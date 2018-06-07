using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerAPI.Models;

namespace ServerAPI.Controllers
{
    public class BlackListController : ApiController
    {
        private TestContext context = new TestContext();

        // GET: api/BlackList
        public IEnumerable<BlackList> Get()
        {
            return this.context.BlackListed.ToArray();
        }

        public BlackList Get(int id)
        {
            return this.context.BlackListed.Find(id);
        }


        // POST: api/BlackList
        public void Post(BlackList value)
        {
            this.context.BlackListed.Add(value);
        }

        // PUT: api/BlackList/5
        public void Put(int id, string value)
        {
        }

        // DELETE: api/BlackList/5
        public void Delete(int id)
        {
        }
    }
}
