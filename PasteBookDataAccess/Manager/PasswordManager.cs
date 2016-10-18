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
        public string GetPasswordHash(string password)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Utility.GetBytes(password);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return Utility.GetString(resultBytes);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == GetPasswordHash(finalString);
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
            byte[] saltBytes = new byte[SALT_SIZE];
            cryptoServiceProvider.GetNonZeroBytes(saltBytes);
            string saltString = Utility.GetString(saltBytes);
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
