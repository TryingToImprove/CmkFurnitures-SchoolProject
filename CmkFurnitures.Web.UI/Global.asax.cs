﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CmkFurnitures.DependencyConfiguration;
using StructureMap;
using CmkFurnitures.Domain.Services;
using System.Configuration;

namespace CmkFurnitures.Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[] { "CmkFurnitures.Web.UI.Controllers" }
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            CmkFurnitures.DependencyConfiguration.DependencyConfiguration.Configure(ConfigurationManager.AppSettings);

            CmkFurnitures.Web.UI.Mappings.AutoMapperBootstrap.ConfigureMappings();
        }

        protected void Application_AuthenticateRequest()
        {
            ObjectFactory.GetInstance<IAdminService>().AuthenticateRequest(Context);
        }
    }
}