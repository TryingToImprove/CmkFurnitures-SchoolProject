using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Models;

namespace CmkFurnitures.Domain.Services
{
    public interface IFurnitureService
    {
        IEnumerable<Furniture> GetAll(string[] includes = null);

        IEnumerable<FurnitureType> GetTypes();

        IEnumerable<Designer> GetDesigners();

        IEnumerable<Furniture> Search(string partNumber, IEnumerable<int> types, int? designerId, int? designYearMin, int? designYearMax, decimal? priceMin, decimal? priceMax);

        Furniture GetByPartNumber(string partNumber);

        Furniture GetById(int id);

        Furniture GetRandom();

        void Update(Furniture furniture);

        void CreateDesigner(string firstName, string lastName);

        Designer GetDesignerById(int id);

        void DeleteDesigner(Designer designer);

        void UpdateDesigner(int id, string p, string p_2);

        void Create(Furniture furniture);

        void SetProfileImage(Furniture furniture, Image image);

        IEnumerable<ImageSizeSpecification> ImageSizes { get; }

        void Delete(Furniture furniture);
    }
}
