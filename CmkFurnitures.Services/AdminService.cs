using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Domain;
using CmkFurnitures.Services.Dependencies;
using System.Web.Security;
using CmkFurnitures.Security;
using System.Web;
using CuttingEdge.Conditions;
using System.Security.Cryptography;

namespace CmkFurnitures.Services
{
    public class AdminService : IAdminService
    {
        private AdminServiceDependencies Dependencies;

        public AdminService(AdminServiceDependencies dependencies)
        {
            this.Dependencies = dependencies;
        }

        public bool Validate(string userName, string password, out Admin admin)
        {
            password = this.Dependencies.HashService.CreateHash(password);

            admin = this.Dependencies.AdminRepository.GetByUserNameAndPassword(userName, password);

            return (admin != null);
        }

        public void SignIn(Domain.Admin admin, HttpResponseBase httpResponseBase)
        {
            this.Dependencies.CustomFormsAuthentication.SignIn(admin.AdminId, admin.UserName, admin.Author.FirstName, admin.Author.LastName, admin.IsSystemUser, httpResponseBase);
        }


        public void AuthenticateRequest(System.Web.HttpContext Context)
        {
            this.Dependencies.CustomFormsAuthentication.AuthenticateRequestDecryptCustomFormsAuthenticationTicket(Context);
        }

        public void SignOut()
        {
            this.Dependencies.CustomFormsAuthentication.SignOut();
        }

        public Admin GetById(int id)
        {
            return this.Dependencies.AdminRepository.GetById(id);
        }


        public IEnumerable<Admin> GetAll()
        {
            return this.Dependencies.AdminRepository.GetAll();
        }


        public void DeleteById(int id)
        {
            this.Dependencies.AdminRepository.Delete(GetById(id));
        }


        public bool UserNameInUse(string username)
        {
            return this.Dependencies.AdminRepository.UserNameInUse(username);
        }


        public void Create(Admin admin)
        {
            Condition.Requires(admin).IsNotNull();
            Condition.Requires(admin.Author).IsNotNull();

            //Set the new password
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA-256");

            byte[] hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(admin.Password));

            admin.Password = Convert.ToBase64String(hash);

            this.Dependencies.AdminRepository.Create(admin);
        }
    }
}
