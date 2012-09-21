using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using System.Web.Mvc;
using CmkFurnitures.Web.UI.DependencySolution.Registries;

namespace CmkFurnitures.Web.UI.DependencySolution
{
    public class DependencyConfiguration
    {
        public static void Configure()
        {
            ObjectFactory.Initialize(
                x =>
                {
                    x.AddRegistry(new ServiceRegistry());
                    x.AddRegistry(new RepositoryRegistry());
                });

            DependencyResolver.SetResolver(new MvcDependencyHandler(ObjectFactory.Container));
        }
    }
}