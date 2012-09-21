using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class ImageSizeRepository : BaseRepository, IImageSizeRepository
    {
        public ImageSizeRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public void Add(ImageSize item)
        {
            Entities.ImageSizes.AddObject(item);
            SaveChanges();
        }

        public void Delete(ImageSize item)
        {
            Entities.ImageSizes.DeleteObject(item);
            SaveChanges();
        }
    }
}
