using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Security;
using CmkFurnitures.Domain.Services;

namespace CmkFurnitures.Services.Dependencies
{
    public class AdminServiceDependencies
    {
        public IAuthorRepository AuthorRepository { get; set; }
        public IAdminRepository AdminRepository { get; set; }
        public ICustomFormsAuthentication CustomFormsAuthentication { get; set; }
        public IHashService HashService { get; set; }
    }
}
