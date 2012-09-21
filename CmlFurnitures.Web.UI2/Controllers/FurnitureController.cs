using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Web.UI.Models;

namespace CmkFurnitures.Web.UI.Controllers
{
    public class FurnitureController : Controller
    {
        //
        // GET: /Furniture/Search/

        public ActionResult Search()
        {
            return View(new SearchFurnitureViewModel("Møbler", "furnitures")
            {
                SearchForm = new SearchFurnitureFormViewModel
                {
                }
            });
        }

        //
        // POST: /Furniture/Search/
        [HttpPost]
        public ActionResult Search(SearchFurnitureFormViewModel requestedViewModel)
        {
            //TODO: PRG pattern for search
            return View();
            return RedirectToAction("SearchResult");
        }

        //
        // GET: /Furniture/Search/

        public ActionResult SearchResult(string[] type, string designer, int? designYearMin, int? designYearMax, int? priceMin, int? priceMax)
        {
            return View();
        }

        //
        // GET: /Furniture/Show/1

        public ActionResult Show(int id)
        {
            return View();
        }

        //
        //GET: PartialOnly
        [ChildActionOnly]
        public ActionResult RandomFurniture()
        {
            return PartialView();
        }
    }
}
