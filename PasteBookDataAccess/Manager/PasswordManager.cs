using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class PasswordManager
    {
        public string GetPasswordHashAndSalt(string message)
        {
            // Let us use SHA256 algorithm to 
            // generate the hash from this salted password
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Utility.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return Utility.GetString(resultBytes);
        }
    }

    public static class SaltGenerator
    {
        private static RNGCryptoServiceProvider cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;
        static SaltGenerator()
        {
            cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
            // Lets create a byte array to store the salt bytes
            byte[] saltBytes = new byte[SALT_SIZE];

            // lets generate the salt in the byte array
            cryptoServiceProvider.GetNonZeroBytes(saltBytes);

            // Let us get some string representation for this salt
            string saltString = Utility.GetString(saltBytes);

            // Now we have our salt string ready lets return it to the caller
            return saltString;
        }
    }

    public class Utility
    {
        public static byte[] GetBytes(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }

        public static string GetString(byte[] resultBytes)
        {
            return Encoding.ASCII.GetString(resultBytes);
        }
    }
    
}
