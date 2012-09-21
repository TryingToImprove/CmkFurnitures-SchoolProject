using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public Image Add(Image image, Furniture furniture)
        {
            furniture.Images.Add(image);
            SaveChanges();

            return image;
        }

        public void Delete(Image item)
        {
            Entities.Images.DeleteObject(item);
            SaveChanges();
        }

        public Image GetById(int id)
        {
            return Entities.Images.FirstOrDefault(x => x.ImageId.Equals(id));
        }
    }
}
