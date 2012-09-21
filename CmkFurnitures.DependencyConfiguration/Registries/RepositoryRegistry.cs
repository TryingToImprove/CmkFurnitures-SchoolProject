using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.DAL.MSSQL.Repositories;
using CmkFurnitures.Domain;
using CmkFurnitures.DAL.Xml;
using System.Xml;

namespace CmkFurnitures.DependencyConfiguration.Registries
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IFurnitureRepository>()
                .Use(factory =>
                {
                    return new FurnitureRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<IFurnitureTypeRepository>()
                .Use(factory =>
                {
                    return new FurnitureTypeRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<IDesignerRepository>()
                .Use(factory =>
                {
                    return new DesignerRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<IImageRepository>()
                .Use(factory =>
                {
                    return new ImageRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<IImageSizeRepository>()
                .Use(factory =>
                {
                    return new ImageSizeRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<IArticleRepository>()
                .Use(factory =>
                {
                    return new ArticleRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<IAuthorRepository>()
                .Use(factory =>
                {
                    return new AuthorRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<IAdminRepository>()
                .Use(factory =>
                {
                    return new AdminRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            For<ISubscriberRepository>()
                .Use(factory =>
                {
                    return new SubscriberRepository(factory.GetInstance<CmkFurnituresDbEntities>());
                });

            //XML

            For<IStoreDetailsRepository>()
                .Use(factory =>
                {
                    string xmlLocation = HttpContext.Current.Server.MapPath("~/App_Data/storedetails.xml");

                    return new StoreDetailsRepository(xmlLocation);
                });
        }
    }
}