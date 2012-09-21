using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IFurnitureRepository : IGenericRepository<Furniture>
    {
        IEnumerable<Furniture> GetAll(string[] includes = null);
        IEnumerable<Furniture> Search(string partNumber, IEnumerable<int> types, int? designerId, int? designYearMin, int? designYearMax, decimal? priceMin, decimal? priceMax);
        Furniture GetByPartNumber(string partNumber);
        Furniture GetById(int id);
        void Update(Furniture furniture);
        Furniture GetRandom();
        void Delete(Furniture furniture);
        void Add(Furniture furniture);
    }
}
