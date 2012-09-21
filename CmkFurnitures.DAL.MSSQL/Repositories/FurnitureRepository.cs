using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;
using System.Linq.Expressions;
using System.Data.Objects;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class FurnitureRepository : BaseRepository, IFurnitureRepository
    {
        public FurnitureRepository(CmkFurnituresDbEntities entities) : base(entities) { }

        public void Add(Furniture item)
        {
            Entities.Furnitures.AddObject(item);
            SaveChanges();
        }

        public IEnumerable<Furniture> GetAll(string[] includes = null)
        {
            ObjectQuery<Furniture> furnitures = Entities.Furnitures;

            if (includes != null && includes.Count() > 0)
            {
                foreach (string include in includes)
                {
                    furnitures = furnitures.Include(include);
                }
            }

            return furnitures.ToArray();
        }

        public IEnumerable<Furniture> Search(string partNumber, IEnumerable<int> types, int? designerId, int? designYearMin, int? designYearMax, decimal? priceMin, decimal? priceMax)
        {
            ObjectQuery<Furniture> furnitures = Entities.Furnitures
                .Include("Images")
                .Include("Images.ImageSizes");

            if (!string.IsNullOrWhiteSpace(partNumber))
            {
                furnitures = (ObjectQuery<Furniture>)furnitures.Where(x => x.PartNumber.Contains(partNumber));
            }

            if (types.Count() > 0)
            {
                furnitures = (ObjectQuery<Furniture>)furnitures.Where(x => types.Contains(x.FurnitureTypeId));
            }

            if (designerId.HasValue)
            {
                furnitures = (ObjectQuery<Furniture>)furnitures.Where(x => x.DesignerId == designerId);
            }

            if (designYearMin.HasValue)
            {
                furnitures = (ObjectQuery<Furniture>)furnitures.Where(x => x.DesignYear > designYearMin);
            }

            if (designYearMax.HasValue)
            {
                furnitures = (ObjectQuery<Furniture>)furnitures.Where(x => x.DesignYear < designYearMax);
            }

            if (priceMin.HasValue)
            {
                furnitures = (ObjectQuery<Furniture>)furnitures.Where(x => x.Price > priceMin);
            }

            if (priceMax.HasValue)
            {
                furnitures = (ObjectQuery<Furniture>)furnitures.Where(x => x.Price < priceMax);
            }

            return furnitures;
        }

        public Furniture GetByPartNumber(string partNumber)
        {
            return Entities.Furnitures
                .Include("Images")
                .Include("Images.ImageSizes")
                .FirstOrDefault(x => x.PartNumber == partNumber);
        }

        public Furniture GetById(int id)
        {
            return Entities.Furnitures
                .Include("Images")
                .Include("Images.ImageSizes")
                .FirstOrDefault(x => x.FurnitureId == id);
        }

        public Furniture GetRandom()
        {
            int count = Entities.Furnitures.Count();

            return Entities.Furnitures
                .Include("Images")
                .Include("Images.ImageSizes")
                .OrderBy(x => x.PartNumber)
                .Skip(new Random().Next(count))
                .FirstOrDefault();
        }

        public void Update(Furniture furniture)
        {
            SaveChanges();
        }


        public void Delete(Furniture furniture)
        {
            Entities.Furnitures.DeleteObject(furniture);
            SaveChanges();
        }
    }
}
