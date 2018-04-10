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
    public class DestinationController : ApiController
    {
        private TestContext context;


        public DestinationController()
        {
            this.context = new TestContext();
        }


        // GET: api/Destination/5
        public List<Destination> Get(int id)
        {
            List<Destination> destinations = this.context.Destinations.ToList();
            List<Destination> result = new List<Destination>();

            foreach(Destination dest in destinations)
            {
                if (dest.IdTask == id)
                {
                   result.Add(dest);
                    continue;
                }

            }

            return result;

        }

        // POST: api/Destination
        public void Post(Destination destination)
        {
            Destination temp = this.context.Destinations.Find(destination.Id);

            if (temp != null)
            {
                temp.Id = destination.Id;
                temp.IdTask = destination.IdTask;
                temp.Port = destination.Port;
                temp.DestinationAddress = destination.DestinationAddress;
                temp.DestinationPassword = destination.DestinationPassword;
                temp.DestinationType = destination.DestinationType;
                temp.DestinationUser = destination.DestinationUser;
                

            }
            else
            {
                this.context.Destinations.Add(destination);
            }

            this.context.SaveChanges();


        }

        //// PUT: api/Destination/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Destination/5
        //public void Delete(int id)
        //{
        //}
    }
}
