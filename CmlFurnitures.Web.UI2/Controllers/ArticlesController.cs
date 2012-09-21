using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Web.UI.Models;

namespace CmkFurnitures.Web.UI.Controllers
{
    public class ArticlesController : Controller
    {
        //
        // GET: /Articles/

        public ActionResult Index()
        {
            return View(new IndexArticlesViewModel("Forside", "articles")
            {
                Articles = null
            });
        }

    }
}
