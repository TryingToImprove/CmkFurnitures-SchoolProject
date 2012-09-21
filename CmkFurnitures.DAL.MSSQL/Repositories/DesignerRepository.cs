using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class DesignerRepository : BaseRepository, IDesignerRepository
    {
        public DesignerRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public void Add(Designer item)
        {
            Entities.Designers.AddObject(item);

            SaveChanges();
        }

        public void Update(Designer item)
        {
            SaveChanges();
        }

        public IEnumerable<Designer> GetAll()
        {
            return Entities.Designers.ToArray();
        }

        public Designer GetById(int id)
        {
            return Entities.Designers.FirstOrDefault(x => x.DesignerId == id);
        }

        public void Delete(Designer designer)
        {
            Entities.Designers.DeleteObject(designer);
            SaveChanges();
        }


        public void Update(int id, string firstName, string lastName)
        {
            Designer designer = Entities.Designers.First(x => x.DesignerId == id);
            designer.FirstName = firstName;
            designer.LastName = lastName;

            SaveChanges();
        }
    }
}
