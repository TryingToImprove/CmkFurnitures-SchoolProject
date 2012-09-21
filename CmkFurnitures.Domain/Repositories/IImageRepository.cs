using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Image Add(Image image, Furniture furniture);
        void Delete(Image image);
        Image GetById(int id);
    }
}
