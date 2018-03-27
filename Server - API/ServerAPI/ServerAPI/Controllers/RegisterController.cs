using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerAPI.Models;
using System.Web.Http.Cors;

namespace ServerAPI.Controllers
{
    [Authorize]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class RegisterController : ApiController
    {
        private TestContext context = new TestContext();
        private Encrypter crypt = new Encrypter();
        // POST: api/Register
        public void Post(User user)
        {

            user.Password = crypt.HashPassword(user.Password);

            this.context.Users.Add(user);
            this.context.SaveChanges();



        }

       
    }
}
