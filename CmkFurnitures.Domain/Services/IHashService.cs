using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Services
{
    public interface IHashService
    {
        string CreateHash(string @string);
        string CreateHash(string @string, string hashAlgorithm);
    }
}
