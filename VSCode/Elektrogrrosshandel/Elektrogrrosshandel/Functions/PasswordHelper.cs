using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Elektrogrosshandel;

namespace Elektrogrosshandel.Functions
{
    internal class PasswordHelper
    {
        private const int _saltSize = 16;
        private const int _hashSize = 32;
        private const int _iterations = 10000;

        private static byte[] GenerateSalt(int size = _saltSize)
        {
            var saltBytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return saltBytes;
        }

        public static string HashPassword(string password, byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                _iterations,
                HashAlgorithmName.SHA256,
                _hashSize);
            return Convert.ToBase64String(hash);
        }
        public static string HashPassword(string password, out byte[] Salt)
        {
            byte[] salt = GenerateSalt();
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt ,
                _iterations,
                HashAlgorithmName.SHA256,
                _hashSize);

            Salt = salt;
            return Convert.ToBase64String(hash);
        }
        public static bool VerifyPassword(string userName, string password)
        {
            byte[] salt = Account.GetAccountSalt(userName);
            string storedHash = Account.GetAccountPasswordHash(userName);
            string passwordHash = HashPassword(password, salt);
            
            if (passwordHash == storedHash)
            {
                return true;
            }

            return false;
        }
    }
}
