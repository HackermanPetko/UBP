using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ServerAPI.Models
{
    public class Encrypter
    {


        public string HashPassword(string password)
        {

            string myPassword = password + "C?l1@`~x";
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashed = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt); 

                        
            
            return hashed;
        }

        public bool CheckPassword(string userPassword, string dbHash)
        {

            if (BCrypt.Net.BCrypt.Verify(userPassword + "C?l1@`~x", dbHash))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}