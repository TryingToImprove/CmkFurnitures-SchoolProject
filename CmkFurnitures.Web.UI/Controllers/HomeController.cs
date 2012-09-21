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
        protected IArticleService ArticleServive;
        public HomeController(IFurnitureService funitureService, IArticleService articleService)
        {
            this.FurnitureService = funitureService;
            this.ArticleServive = articleService;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(new IndexHomeViewModel("Forside", "home")
            {
                Articles = ArticleServive.GetNewest(3)
            });
        }
    }
}
