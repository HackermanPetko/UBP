using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerAPI.Controllers
{
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
        public void Post(Daemon daemon)
        {
            this.context.Daemons.Add(daemon);
            this.context.SaveChanges();
        }

        // PUT: api/Daemons/5
        public void Put(int id, Daemon daemon)
        {
            Daemon temp = this.context.Daemons.Find(id);

            temp.DaemonName = daemon.DaemonName;
            temp.idDaemon = daemon.idDaemon;
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
