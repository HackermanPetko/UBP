using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerAPI.Controllers
{
    [Authorize]
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
        public Backup Get(int id)
        {
            return this.context.Backups.Find(id);
        }

        // POST: api/Backups
        public void Post(Backup backup)
        {
            this.context.Backups.Add(backup);
            this.context.SaveChanges();
        }

        // PUT: api/Backups/5
        public void Put(int id, Backup backup)
            {
            Backup temp = this.context.Backups.Find(id);

            temp.BackupType = backup.BackupType;
            temp.Date = backup.Date;
            temp.ErrorMsg = backup.ErrorMsg;
            temp.Id = backup.Id;
            temp.idDaemon = backup.idDaemon;
            temp.LogLocation = backup.LogLocation;
            temp.State = backup.State;

            this.context.SaveChanges();

        }

        // DELETE: api/Backups/5
        public void Delete(int id)
        {
            this.context.Configs.Remove(this.context.Configs.Find(id));
            this.context.SaveChanges();
        }
    }
}
