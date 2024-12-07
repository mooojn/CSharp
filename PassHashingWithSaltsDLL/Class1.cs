using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PassHashingWithSaltsDLL
{
    public class Hashing
    {
        public static string ComputeSha256Hash(string rawData, string salt)
        {
            rawData += salt;
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static string GenerateSalt()
        {
            Random random = new Random();

            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            int maxLength = random.Next(10, 21);

            string salt = "";
            for (int i = 0; i < maxLength; i++)
            {
                int randomIndex = random.Next(0, allowedChars.Length);
                salt += Convert.ToString(allowedChars[randomIndex]);
            }

            return salt;
        }
    }
}
