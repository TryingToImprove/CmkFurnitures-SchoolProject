using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IImageSizeRepository : IGenericRepository<ImageSize>
    {
        void Add(ImageSize imageSize);
        void Delete(ImageSize imageSize);
    }
}
