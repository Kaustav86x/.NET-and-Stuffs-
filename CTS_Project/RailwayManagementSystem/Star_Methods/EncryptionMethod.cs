using System;
using System.Security.Cryptography;
using System.Text;

namespace RailwayManagementSystem.Star_Methods
{
    public class EncryptionMethod
    {
        public static string EncryptString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute the hash value of the input byte array
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert the hash byte array to a hexadecimal string representation
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                // Return the encrypted string
                return sb.ToString();
            }
        }
    }
}



