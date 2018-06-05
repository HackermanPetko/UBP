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
    public class DaemonsController : ApiController
    {
        private TestContext context;

        public DaemonsController()
        {

            context = new TestContext();
        }


        // GET: api/Daemons
        public List<Daemon> Get()
        {
            return this.context.Daemons.ToList();
        }

        // GET: api/Daemons/5
        public Daemon Get(int id)
        {
            return this.context.Daemons.Find(id);
        }

        // POST: api/Daemons
        public IHttpActionResult Post(Daemon daemon)
        {
            Daemon temp;
            
            try
            {
                temp = this.context.FindDaemon(daemon.DaemonMAC);
            }
            catch
            {
                temp = null;
            }

            if (temp == null)
            {

                this.context.Daemons.Add(daemon);
                this.context.SaveChanges();

            }

            if (temp == null)
            {
                this.context.Configs.Add(new Config() { Comment = "default", Id = this.context.FindDaemon(daemon.DaemonMAC).Id, LastChecked = DateTime.Now, TimeStamp = DateTime.Now});

            }

            this.context.SaveChanges();
            return Ok<int>(this.context.FindDaemon(daemon.DaemonMAC).Id);
        }

        // PUT: api/Daemons/5
        public void Put(int id, Daemon daemon)
        {
            Daemon temp = this.context.Daemons.Find(id);

            temp.DaemonName = daemon.DaemonName;
            temp.Id = daemon.Id;
            temp.IsNew = daemon.IsNew;
            temp.DaemonMAC = daemon.DaemonMAC;
            temp.LastConnected = daemon.LastConnected;

            this.context.SaveChanges();
        }

        // DELETE: api/Daemons/5
        public void Delete(int id)
        {
            this.context.Configs.Remove(this.context.Configs.Find(id));
            this.context.SaveChanges();
        }
    }
}
