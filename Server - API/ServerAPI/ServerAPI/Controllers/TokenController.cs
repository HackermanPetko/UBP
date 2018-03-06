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
            if (CheckUser(user.Username, user.Password))
            {
                return SaveToken(user.Username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string username, string password)
        {
            User userFromDB = this.context.Users.Find(this.context.FindUser(username).ID);

            if (userFromDB.Password == password)
                return true;
            else
                return false;



        }

        public string SaveToken(string username) {

            User user = this.context.FindUser(username);
            string token = JwtManager.GenerateToken(user.Username);
            Token newToken = new Token();
            newToken.IdUser = user.ID;
            newToken.UserToken = token;
            newToken.IsValid = true;
            this.context.Tokens.Add(newToken);
            this.context.SaveChanges();
            

            return token;
        }

      
       
    }
}
