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

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SourceController : ApiController
    {
        private TestContext context;

        public SourceController()
        {
            this.context = new TestContext();
        }

        // GET: api/Source/5
        public List<Source> Get(int id)
        {
            List<Source> sources = this.context.Sources.ToList();
            List<Source> result = new List<Source>();

            foreach (Source src in sources)
            {
                if (src.IdTask == id)
                {
                    result.Add(src);
                    continue;
                }

            }

            return result;

        }

        // POST: api/Source
        public void Post(Source source)
        {
            Source temp = this.context.Sources.Find(source.Id);

            if (temp != null)
            {
                temp.Id = source.Id;
                temp.IdTask = source.IdTask;
                temp.SourcePath = source.SourcePath;

            }
            else
            {
                this.context.Sources.Add(source);
            }

            this.context.SaveChanges();



        }

        //// PUT: api/Source/5
        public void Put(Source source)
        {
            this.context.Sources.Remove(this.context.Sources.Find(source.Id));
            this.context.SaveChanges();

        }

        //// DELETE: api/Source/5
        //public void Delete(int id)
        //{
        //}
    }
}
