using ServerAPI.Models;
using ServerAPI.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace ServerAPI.Controllers
    {
    [Authorize]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ConfigController : ApiController
    {
        private TestContext context;

        public ConfigController()
        {
            this.context = new TestContext();
        }

        // GET: api/Config
        public List<Config> Get()
        {
            //List<Config> list = this.context.Configs.ToList();
            //return JsonConvert.SerializeObject(list);
            return this.context.Configs.ToList();
        }

        // GET: api/Config/5
        public Config Get(int id)
        {
            //return this.context.Configs.Where(x => x.Id == id).ToList().First();

            try
            {

                List<Config> configs = this.context.Configs.ToList();
                List<Config> result = new List<Config>();

                foreach (Config config in configs)
                {
                    if (config.Id == id)
                    {
                        result.Add(config);
                        continue;
                    }

                }


                return result.First();
            }
            catch
            {
                this.context.NewConfig(id);
                return this.context.Configs.Find(id);
            }
           


        }


        // POST: api/Config
        public void Post(Config config)
        {
            Config temp = this.context.Configs.Find(config.Id);

            if (temp != null)
            {
                temp.Id = config.Id;
                temp.LastChecked = config.LastChecked;
                temp.Comment = config.Comment;
                temp.TimeStamp = config.TimeStamp;


            }
            else
            {
              this.context.Configs.Add(config);
            }
            
            this.context.SaveChanges();
        }

        // PUT: api/Config/5
        public void Put(int id, Config config)
        {
            Config temp = this.context.Configs.Find(id);



            //temp.Interval = config.Interval;
            //temp.LastChecked = config.LastChecked;
            //temp.Repeatable = config.Repeatable;
            //temp.FTPport = config.FTPport;
            //temp.DestinationUser = config.DestinationUser;
            //temp.DestinationType = config.DestinationType;
            //temp.DestinationPassword = config.DestinationPassword;
            //temp.DestinationAddress = config.DestinationAddress;
            //temp.BackupType = config.BackupType;
            temp.TimeStamp = config.TimeStamp;

            this.context.SaveChanges();

        }

        // DELETE: api/Config/5
        public void Delete(int id)
        {
            this.context.Configs.Remove(this.context.Configs.Find(id));
            this.context.SaveChanges();
        }
    }
}
