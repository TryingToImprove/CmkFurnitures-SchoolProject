using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Web.UI.Models;
using CmkFurnitures.Domain.Services;

namespace CmkFurnitures.Web.UI.Controllers
{
    public class ArticlesController : Controller
    {
        protected IArticleService ArticleService;

        public ArticlesController(IArticleService articleService)
        {
            this.ArticleService = articleService;
        }

        //
        // GET: /Articles/

        public ActionResult Index()
        {
            return View(new IndexArticlesViewModel("Nyheder", "articles")
            {
                Articles = ArticleService.GetAll().OrderByDescending(x => x.CreationDate)
            });
        }

    }
}
