using AccountingBookBL.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AccountingBookBL.Services.Implementations
{
    public class HashService : IHashService
    {
        public string GetHash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password can not be empty");
            }
            byte[] passwordByte = Encoding.Default.GetBytes(password);
            SHA1CryptoServiceProvider cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(
      cryptoTransformSha1.ComputeHash(passwordByte)).Replace("-", "");
            return hash;
        }
    }
}
