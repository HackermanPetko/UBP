using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ServerAPI.Models
{
    public class Encrypter
    {

        static string myPassword="0";
        static string mySalt = "$2a$10$rBV2JDeWW3.vKyeQcM8fFO";

       
        //mySalt == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO"
        static string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
        //myHash == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO4777l4bVeQgDL6VIkxqlzQ7TCalQvla"
        bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(myPassword,myHash);


    }
}