using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Admin GetByUserNameAndPassword(string userName, string password);

        IEnumerable<Admin> GetAll();

        void Delete(Admin admin);

        Admin GetById(int id);

        bool UserNameInUse(string username);

        void Create(Admin admin);
    }
}
