using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class AdminRepository : BaseRepository, IAdminRepository
    {
        public AdminRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public void Add(Admin item)
        {
            throw new NotImplementedException();
        }

        public Admin GetByUserNameAndPassword(string userName, string password)
        {
            return Entities.Admins.FirstOrDefault(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password, StringComparison.OrdinalIgnoreCase));
        }


        public IEnumerable<Admin> GetAll()
        {
            return Entities.Admins.Where(x => !x.IsSystemUser);
        }


        public void Delete(Admin admin)
        {
            Entities.Admins.DeleteObject(admin);
            SaveChanges();
        }

        public Admin GetById(int id)
        {
            return Entities.Admins.FirstOrDefault(x => x.AdminId == id);
        }


        public bool UserNameInUse(string username)
        {
            return Entities.Admins.Any(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }


        public void Create(Admin admin)
        {
            Entities.Admins.AddObject(admin);
            SaveChanges();
        }
    }
}
