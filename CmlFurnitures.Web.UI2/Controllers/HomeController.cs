using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Web.UI.Models;

namespace CmkFurnitures.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        protected IFurnitureService FurnitureService;
        public HomeController(IFurnitureService funitureService)
        {
            this.FurnitureService = funitureService;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(new IndexHomeViewModel("Forside", "home")
            {
                Articles = null
            });
        }
    }
}
