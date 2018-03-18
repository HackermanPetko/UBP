using Microsoft.IdentityModel.Tokens;
using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ServerAPI
{
    internal class TokenValidationHandler : DelegatingHandler
    {
        private TestContext context;

        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            //determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                const string sec = "92AyTtADbKyaJmq2CxnQ5gJXKQ44BJ8Z4BJxkFrZxYUDZCRDjYd7KY5NHCHdV6B365bDk3kkJkRMP4gdAXQ4CGAxbcbgBLwaQ8JsSJNmCzXLSUkydbhRjhnhQ3hYYLxRKbMsc5sGWqXaqbJGaHWhVLCdtcdtHf9Wb8ZukW4C6F2scxHtwpRWrVuSxqjKaHtAMpVmwQC5yn5asjk9ezYuSxdgpjyt83WDQWvBLsubAcYFcXEFXUQXvnae9K9xLCaf";
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));


                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "http://localhost:63699",
                    ValidIssuer = "http://localhost:63699",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                if (this.context.FindToken(token).IsValid)
                {
                    Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                    HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);

                    return base.SendAsync(request, cancellationToken);
                }
                else { throw new UnauthorizedAccessException("You were banned"); }
            }
            catch (SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }


    }
}