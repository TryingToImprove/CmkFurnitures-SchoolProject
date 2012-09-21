using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services.Dependencies;
using CmkFurnitures.Domain;
using CmkFurnitures.Domain.Services;
using System.Linq.Expressions;
using CuttingEdge.Conditions;
using CmkFurnitures.Domain.Models;

namespace CmkFurnitures.Services
{
    public class FurnitureService : IFurnitureService
    {
        IFurnitureServiceDependencies Dependencies;

        public IEnumerable<ImageSizeSpecification> ImageSizes
        {
            get
            {
                return new ImageSizeSpecification[]{
                    new ImageSizeSpecification(120, 90),
                    new ImageSizeSpecification(50,50),
                    new ImageSizeSpecification(300,225)
                };
            }
        }


        public FurnitureService(IFurnitureServiceDependencies dependencies)
        {
            this.Dependencies = dependencies;
        }

        public IEnumerable<Furniture> GetAll(string[] includes = null)
        {
            return this.Dependencies.FurnitureRepository.GetAll(includes);
        }

        public IEnumerable<FurnitureType> GetTypes()
        {
            return this.Dependencies.FurnitureTypeRepository.GetAll();
        }

        public IEnumerable<Designer> GetDesigners()
        {
            return this.Dependencies.DesignerRepository.GetAll();
        }

        public IEnumerable<Furniture> Search(string partNumber, IEnumerable<int> types, int? designerId, int? designYearMin, int? designYearMax, decimal? priceMin, decimal? priceMax)
        {
            if (types == null)
            {
                types = new int[0];
            }

            return this.Dependencies.FurnitureRepository.Search(partNumber, types, designerId, designYearMin, designYearMax, priceMin, priceMax);
        }

        public Furniture GetByPartNumber(string partNumber)
        {
            Condition.Requires(partNumber).IsNotNullOrWhiteSpace();

            return this.Dependencies.FurnitureRepository.GetByPartNumber(partNumber);
        }

        public Furniture GetById(int id)
        {
            Condition.Requires(id).IsGreaterThan(0);

            return this.Dependencies.FurnitureRepository.GetById(id);
        }

        public Furniture GetRandom()
        {
            return this.Dependencies.FurnitureRepository.GetRandom();
        }

        public void Update(Furniture furniture)
        {
            Validate.Furniture(furniture);

            //Update requires that the furniture have the partnumber
            Condition.Requires(furniture.PartNumber).IsNotNullOrWhiteSpace();

            this.Dependencies.FurnitureRepository.Update(furniture);
        }

        public class Validate
        {
            public static void Furniture(Furniture furniture)
            {
                Condition.Requires(furniture).IsNotNull();
                Condition.Requires(furniture.Name).IsNotNullOrWhiteSpace();
                Condition.Requires(furniture.Price).IsGreaterThan(0);
                Condition.Requires(furniture.Text).IsNotNullOrWhiteSpace();
            }
            public static void Designer(string firstName, string lastName)
            {
                Condition.Requires(firstName).IsNotNullOrWhiteSpace();
                Condition.Requires(lastName).IsNotNullOrWhiteSpace();
            }
            public static void Designer(Designer designer)
            {
                Condition.Requires(designer).IsNotNull();
                Condition.Requires(designer.DesignerId).IsGreaterThan(0);
            }
        }


        public void CreateDesigner(string firstName, string lastName)
        {
            Validate.Designer(firstName, lastName);

            Dependencies.DesignerRepository.Add(new Designer { LastName = lastName, FirstName = firstName });
        }


        public Designer GetDesignerById(int id)
        {
            return Dependencies.DesignerRepository.GetById(id);
        }

        public void DeleteDesigner(Designer designer)
        {
            Validate.Designer(designer);
            Dependencies.DesignerRepository.Delete(designer);
        }


        public void UpdateDesigner(int id, string firstName, string lastName)
        {
            Validate.Designer(firstName, lastName);
            Dependencies.DesignerRepository.Update(id, firstName, lastName);
        }


        public void Create(Furniture furniture)
        {
            Dependencies.FurnitureRepository.Add(furniture);
        }

        public void SetProfileImage(Furniture furniture, Image image)
        {
            Condition.Requires(furniture).IsNotNull();

            Condition.Requires(image).IsNotNull();
            Condition.Requires(image.ImageId).IsGreaterThan(0);

            furniture.ProfileImageId = image.ImageId;

            Dependencies.FurnitureRepository.Update(furniture);
        }

        public void Delete(Furniture furniture)
        {
            Dependencies.FurnitureRepository.Delete(furniture);
        }
    }
}
