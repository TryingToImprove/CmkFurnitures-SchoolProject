using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Web.UI.Models;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Controllers
{
    public class FurnitureController : Controller
    {
        protected IFurnitureService FurnitureService;

        public FurnitureController(IFurnitureService funitureService)
        {
            this.FurnitureService = funitureService;
        }

        //
        // GET: /Furniture/Search/

        public ActionResult Search()
        {
            return View(new SearchFurnitureViewModel("Møbler", "furnitures")
            {
                SearchForm = new SearchFurnitureFormViewModel
                {
                    Types = FurnitureService.GetTypes(),
                    Designers = FurnitureService.GetDesigners().Select(x => new KeyValuePair<string, string>(x.FullName, x.DesignerId.ToString()))
                }
            });
        }

        //
        // POST: /Furniture/Search/
        [HttpPost]
        public ActionResult Search(SearchFurnitureFormViewModel requestedViewModel)
        {
            var results = FurnitureService.Search(
                requestedViewModel.PartNumber,
                requestedViewModel.SelectedTypes,
                requestedViewModel.SelectedDesigner,
                requestedViewModel.Year.Min,
                requestedViewModel.Year.Max,
                requestedViewModel.Price.Min,
                requestedViewModel.Price.Max
            );

            if (results.Count(x => x.PartNumber == requestedViewModel.PartNumber) == 1)
            {
                return RedirectToAction("Show", new { id = requestedViewModel.PartNumber });
            }
            else if (results.Count() == 0)
            {
                requestedViewModel.Types = FurnitureService.GetTypes();
                requestedViewModel.Designers = FurnitureService.GetDesigners().Select(x => new KeyValuePair<string, string>(x.FullName, x.DesignerId.ToString()));
                ViewBag.NoResults = true;
                return View("Search", new SearchFurnitureViewModel("Møbler", "furnitures")
                {
                    SearchForm = requestedViewModel
                });
            }

            return View("SearchResult", new SearchResultFurnitureViewModel("Møbler", "furnitures")
            {
                Results = results
            });
        }

        //
        // GET: /Furniture/Show/1

        public ActionResult Show(string id)
        {
            Furniture furniture = FurnitureService.GetByPartNumber(id);

            if (furniture == null)
            {
                return RedirectToActionPermanent("Search");
            }

            return View(new ShowFurnitureViewModel("Møbler", "furnitures")
            {
                Furniture = furniture
            });
        }

        //
        //GET: PartialOnly
        [ChildActionOnly]
        public ActionResult RandomFurniture()
        {
            return PartialView(new RandomFurnitureViewModel
            {
                Furniture = FurnitureService.GetRandom()
            });
        }
    }
}
