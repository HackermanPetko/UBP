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
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TokenController : ApiController
    {

        private TestContext context = new TestContext();

        //// GET: api/Token
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Token/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Token
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Token/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Token/5
        public void Post(Token token)
        {
            Token selToken = this.context.FindToken(token.UserToken);

            this.context.Tokens.Remove(selToken);
            this.context.SaveChanges();

        }

    }
}
