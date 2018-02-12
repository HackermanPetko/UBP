using ServerAPI.Models;
using ServerAPI.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerAPI.Controllers
{
    public class ConfigController : ApiController
    {
        private TestContext context;

        private List<Config> list;

        public ConfigController()
        {
            this.context = new TestContext();
            this.list = new List<Config>();
        }

        // GET: api/Config
        public List<Config> Get()
        {
            return this.context.Configs.ToList();
        }

        // GET: api/Config/5
        public Config Get(int id)
        {
            return this.context.Configs.Find(id);
        }

        // POST: api/Config
        public void Post(Config config)
        {
            this.context.Configs.Add(config);
            this.context.SaveChanges();
        }

        // PUT: api/Config/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Config/5
        public void Delete(int id)
        {
        }
    }
}
