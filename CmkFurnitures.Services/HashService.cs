using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services;
using System.Security.Cryptography;

namespace CmkFurnitures.Services
{
    public class HashService : IHashService
    {
        string Prefix;

        public HashService(string prefix)
        {
            this.Prefix = prefix;
        }

        public string CreateHash(string @string)
        {
            return CreateHash(@string, "SHA-256");
        }

        public string CreateHash(string @string, string hashAlgorithm)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create(hashAlgorithm);

            byte[] hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(this.Prefix + @string));

            return Convert.ToBase64String(hash);
        }
    }
}
