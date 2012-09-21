using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using System.Web.Mvc;
using CmkFurnitures.DependencyConfiguration.Registries;
using CmkFurnitures.Domain;
using CmkFurnitures.Security;
using CmkFurnitures.Security.Authentication;
using System.Collections.Specialized;

namespace CmkFurnitures.DependencyConfiguration
{
    public class DependencyConfiguration
    {
        public static void Configure(NameValueCollection appSettings)
        {
            ObjectFactory.Initialize(
                x =>
                {
                    x.For<CmkFurnituresDbEntities>()
                        .Singleton()
                        .Use(_ =>
                        {
                            return new CmkFurnituresDbEntities();
                        });

                    x.AddRegistry(new ServiceRegistry(appSettings));
                    x.AddRegistry(new RepositoryRegistry());

                    x.For<ICustomFormsAuthentication>().Use<CustomFormsAuthentication>()
                    .Named("Custom Forms Authentication instance.");
                });

            DependencyResolver.SetResolver(new MvcDependencyHandler(ObjectFactory.Container));
        }
    }
}