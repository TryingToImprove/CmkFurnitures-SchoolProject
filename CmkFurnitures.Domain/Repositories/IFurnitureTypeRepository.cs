using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IFurnitureTypeRepository : IGenericRepository<FurnitureType>
    {
        IEnumerable<FurnitureType> GetAll();
    }
}
