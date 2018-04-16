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
    public class TaskController : ApiController
    {
        private TestContext context;

        public TaskController()
        {
            this.context = new TestContext();
        }

        //// GET: api/Task
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Task/5
        public List<BackupTask> Get(int id)
        {

            {
                List<BackupTask> tasks = this.context.Tasks.ToList();
                List<BackupTask> result = new List<BackupTask>();

                foreach (BackupTask task in tasks)
                {
                    if (task.IdConfig == id)
                    {
                        result.Add(task);
                        continue;
                    }

                }

                return result;

            }

        }

        // POST: api/Task
        public void Post(BackupTask task)
        {
            BackupTask temp = this.context.Tasks.Find(task.Id);

            if (temp != null)
            {
                temp.BackupType = task.BackupType;
                temp.Format = task.Format;
                temp.Id = task.Id;
                temp.IdConfig = task.MaxBackups;
                temp.RepeatInterval = task.RepeatInterval;
                


            }
            else
            {
                this.context.Tasks.Add(task);
            }

            this.context.SaveChanges();



        }

        //// PUT: api/Task/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Task/5
        //public void Delete(int id)
        //{
        //}
    }
}
