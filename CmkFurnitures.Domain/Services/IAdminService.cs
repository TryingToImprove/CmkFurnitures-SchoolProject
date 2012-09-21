using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CmkFurnitures.Domain.Services
{
    public interface IAdminService
    {
        bool Validate(string userName, string password, out Admin admin);

        void SignIn(Admin admin, HttpResponseBase httpResponseBase);

        void AuthenticateRequest(System.Web.HttpContext Context);

        void SignOut();

        IEnumerable<Admin> GetAll();

        void DeleteById(int id);

        Admin GetById(int id);

        bool UserNameInUse(string username);

        void Create(Admin admin);
    }
}
