using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Encryption
    {
        public static void Encrypt(string heslo)
        {
            int Rfc2898KeygenIterations = 100;
            int AesKeySizeInBits = 128;
            String Password = "Fpsadasd544gf! df";
            byte[] Salt = Encoding.UTF8.GetBytes("AJisjfidpskfoepfKkakso oaksodp");
            byte[] rawPlaintext = System.Text.Encoding.Unicode.GetBytes(heslo);
            byte[] cipherText = null;

            using (Aes aes = new AesManaged())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = AesKeySizeInBits;
                int KeyStrengthInBytes = aes.KeySize / 8;
                System.Security.Cryptography.Rfc2898DeriveBytes rfc2898 =
                    new System.Security.Cryptography.Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
                aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
                aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(rawPlaintext, 0, rawPlaintext.Length);
                    }
                    cipherText = ms.ToArray();
                }

                Settings1.Default.password = Encoding.Unicode.GetString(cipherText);
            }
        }

        public static string Decrypt()
        {
            int Rfc2898KeygenIterations = 100;
            int AesKeySizeInBits = 128;
            byte[] Salt = Encoding.UTF8.GetBytes("AJisjfidpskfoepfKkakso oaksodp");
            String Password = "Fpsadasd544gf! df";

            byte[] plainText = null;

            using (Aes aes = new AesManaged())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = AesKeySizeInBits;
                int KeyStrengthInBytes = aes.KeySize / 8;
                System.Security.Cryptography.Rfc2898DeriveBytes rfc2898 =
                    new System.Security.Cryptography.Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
                aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
                aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        var bytes = Encoding.Unicode.GetBytes(Settings1.Default.password);
                        cs.Write(bytes, 0, bytes.Length);
                    }
                    plainText = ms.ToArray();
                }

                return Encoding.Unicode.GetString(plainText);
            }
        }

    }
}
