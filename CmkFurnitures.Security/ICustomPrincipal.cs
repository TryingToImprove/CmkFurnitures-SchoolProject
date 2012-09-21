using System;
namespace CmkFurnitures.Security
{
    public interface ICustomPrincipal
    {
        CmkFurnitures.Security.ICustomIdentity Identity { get; }
    }
}
