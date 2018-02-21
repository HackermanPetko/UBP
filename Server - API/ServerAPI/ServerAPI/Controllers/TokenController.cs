using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerAPI.Controllers
{
    public class TokenController : ApiController
    {

        private TestContext context;

        public TokenController()
        {
            this.context = new TestContext();
        }



        // POST: api/Token
        public string Post(User user)
        {
            if (CheckUser(user.ID,user.Username, user.Password))
            {
                return JwtManager.GenerateToken(user.Username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(int id,string username, string password)
        {
            User userFromDB = this.context.Users.Find(id);

            if (userFromDB.Password == password)
                return true;
            else
                return false;


            
        }
       
    }
}
