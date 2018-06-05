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
    public class BackupsController : ApiController
    {


        private TestContext context;
        // GET: api/Backups

        public BackupsController(){

            this.context = new TestContext();
        }

        public List<Backup> Get()
        {

            return this.context.Backups.ToList();
        }

        // GET: api/Backups/5
       

        // POST: api/Backups
        public void Post(Backup backup)
        {
            this.context.Backups.Remove(this.context.Backups.Find(backup.Id));
            this.context.SaveChanges();
        }

        
        
    }
}
