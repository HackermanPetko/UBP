using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using ServerAPI.Models;
using System.Web.Http.Cors;

namespace ServerAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LoginController : ApiController
            {

        private TestContext context = new TestContext();
        private LoginRequest user = new LoginRequest();
        private Encrypter crypt = new Encrypter();

        [HttpPost]
        public IHttpActionResult Authenticate(LoginRequest login)
        {

                var loginResponse = new LoginResponse();

                string Username = login.Username.ToString();
                string Password = login.Password.ToString();

                this.user.Username = Username;
                this.user.Password = Password;



                IHttpActionResult response;
                HttpResponseMessage responseMsg = new HttpResponseMessage();



                if (this.CheckUser(this.user.Username, this.user.Password))
                {
                    string token = createToken(user.Username);
                    //return the token
                    this.SaveToken(user.Username, token);
                    return Ok<string>(token);
                }
                else
                {
                    // if credentials are not valid send unauthorized status code in response
                    loginResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                    response = ResponseMessage(loginResponse.responseMsg);
                    return response;
                }

        }

        private string createToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(100);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            const string sec = "92AyTtADbKyaJmq2CxnQ5gJXKQ44BJ8Z4BJxkFrZxYUDZCRDjYd7KY5NHCHdV6B365bDk3kkJkRMP4gdAXQ4CGAxbcbgBLwaQ8JsSJNmCzXLSUkydbhRjhnhQ3hYYLxRKbMsc5sGWqXaqbJGaHWhVLCdtcdtHf9Wb8ZukW4C6F2scxHtwpRWrVuSxqjKaHtAMpVmwQC5yn5asjk9ezYuSxdgpjyt83WDQWvBLsubAcYFcXEFXUQXvnae9K9xLCaf";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:63699", audience: "http://localhost:63699",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public bool CheckUser(string username, string password)
        {
            User userFromDB = this.context.Users.Find(this.context.FindUser(username).ID);

            if (this.crypt.CheckPassword(password,userFromDB.Password))
                return true;
            else
                return false;



        }

        public void SaveToken(string username,string token)
        {

            User user = this.context.FindUser(username);
            Token newToken = new Token();
            newToken.IdUser = user.ID;
            newToken.UserToken = token;
            newToken.IsValid = true;
            this.context.Tokens.Add(newToken);
            this.context.SaveChanges();


           
        }
    }
}
