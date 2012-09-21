using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Services;
using CmkFurnitures.Domain.Services.Dependencies;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Services.Dependencies;
using CmkFurnitures.Security;
using System.Collections.Specialized;

namespace CmkFurnitures.DependencyConfiguration.Registries
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry(NameValueCollection appSettings)
        {
            For<IHashService>()
                .Use(factory =>
                {
                    return new HashService(appSettings["hashPrefix"]);
                });

            For<IFurnitureService>()
                .Use(factory =>
                {
                    return new FurnitureService(
                        new FurnitureServiceDependencies
                        {
                            FurnitureRepository = factory.GetInstance<IFurnitureRepository>(),
                            FurnitureTypeRepository = factory.GetInstance<IFurnitureTypeRepository>(),
                            DesignerRepository = factory.GetInstance<IDesignerRepository>()
                        });
                });

            For<IImageService>()
                .Use(factory =>
                {
                    return new ImageService(
                        new ImageServiceDependencies
                        {
                            ImageRepository = factory.GetInstance<IImageRepository>(),
                            ImageSizeRepository = factory.GetInstance<IImageSizeRepository>()
                        },
                        HttpContext.Current);
                });

            For<IArticleService>()
                .Use(factory =>
                {
                    return new ArticleService(
                        new ArticleServiceDependencies
                        {
                            AdminRepository = factory.GetInstance<IAdminRepository>(),
                            AuthorRepository = factory.GetInstance<IAuthorRepository>(),
                            ArticleRepository = factory.GetInstance<IArticleRepository>()
                        });
                });

            For<IAdminService>()
                .Use(factory =>
                {
                    return new AdminService(
                        new AdminServiceDependencies
                        {
                            AdminRepository = factory.GetInstance<IAdminRepository>(),
                            AuthorRepository = factory.GetInstance<IAuthorRepository>(),
                            CustomFormsAuthentication = factory.GetInstance<ICustomFormsAuthentication>(),
                            HashService = factory.GetInstance<IHashService>()
                        });
                });

            For<IStoreDetailService>()
                .Use(factory =>
                {
                    return new StoreDetailService(
                        new StoreDetailServiceDependencies
                        {
                            StoreDetailsRepository = factory.GetInstance<IStoreDetailsRepository>()
                        });
                });

            For<INewsletterService>()
                .Use(factory =>
                {
                    return new NewsletterService(
                        new NewsletterServiceDependencies
                        {
                            SubscriberRepository = factory.GetInstance<ISubscriberRepository>(),
                            HashService = factory.GetInstance<IHashService>()
                        });
                });
        }
    }
}