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
    public class TaskeditController : ApiController
    {

        private TestContext context;

        public TaskeditController()
        {
            this.context = new TestContext();
        }



        // GET: api/Taskedit
        public List<BackupTask> Get(int id)
        {

            {
                List<BackupTask> tasks = this.context.Tasks.ToList();
                List<BackupTask> result = new List<BackupTask>();

                foreach (BackupTask task in tasks)
                {
                    if (task.Id == id)
                    {
                        result.Add(task);
                        continue;
                    }

                }

                return result;

            }

        }

        

     
    }
}
