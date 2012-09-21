using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class FurnitureTypeRepository : BaseRepository, IFurnitureTypeRepository
    {
        public FurnitureTypeRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public void Add(FurnitureType item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FurnitureType> GetAll()
        {
            return Entities.FurnitureTypes.ToArray();
        }
    }
}
