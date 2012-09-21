using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IDesignerRepository : IGenericRepository<Designer>
    {
        IEnumerable<Designer> GetAll();

        Designer GetById(int id);

        void Delete(Designer designer);

        void Update(int id, string firstName, string lastName);

        void Add(Designer designer);
    }
}
