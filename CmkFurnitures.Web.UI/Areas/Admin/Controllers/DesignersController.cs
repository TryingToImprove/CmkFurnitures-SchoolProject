using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Web.UI.Areas.Admin.Models;
using CmkFurnitures.Domain;
using AutoMapper;

namespace CmkFurnitures.Web.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class DesignersController : BaseController
    {
        protected IFurnitureService FurnitureService;

        public DesignersController(IFurnitureService funitureService)
        {
            this.FurnitureService = funitureService;
        }

        //
        // GET: /Admin/Designer/

        public ActionResult Index()
        {
            return View(new IndexDesignersViewModel
            {
                Designers = FurnitureService.GetDesigners()
            });
        }

        //
        // GET: /Admin/Designer/Create

        public ActionResult Create()
        {
            return View(new CreateDesignersViewModel
            {
                DesignerForm = new DesignerFormViewModel()
            });
        }


        //
        // POST: /Admin/Designer/Create

        [HttpPost]
        public ActionResult Create(CreateDesignersViewModel requestedViewModel)
        {
            if (ModelState.IsValid)
            {
                FurnitureService.CreateDesigner(requestedViewModel.DesignerForm.FirstName, requestedViewModel.DesignerForm.LastName);

                return RedirectToAction("Index");
            }

            return View(requestedViewModel);
        }

        //
        // GET: /Admin/Designer/Update/1

        public ActionResult Update(int id)
        {
            Designer designer = FurnitureService.GetDesignerById(id);

            return View(new UpdateDesignersViewModel
            {
                DesignerForm = Mapper.Map<Designer, DesignerFormViewModel>(designer)
            });
        }


        //
        // POST: /Admin/Designer/Update/1

        [HttpPost]
        public ActionResult Update(int id, UpdateDesignersViewModel requestedViewModel)
        {
            Designer designer = FurnitureService.GetDesignerById(id);

            if (ModelState.IsValid)
            {
                FurnitureService.UpdateDesigner(id, requestedViewModel.DesignerForm.FirstName, requestedViewModel.DesignerForm.LastName);

                return RedirectToAction("Index");
            }

            return View(requestedViewModel);
        }

        public ActionResult Delete(int id)
        {
            Designer designer = FurnitureService.GetDesignerById(id);

            if (designer == null)
            {
                return View("NotFound");
            }
            else if (designer.Furnitures.Count() > 0)
            {
                return View("NotDeleted", new NotDeletedDesignerViewModel
                {
                    Designer = designer
                });
            }
            else
            {
                FurnitureService.DeleteDesigner(designer);
                return View("Deleted");
            }
        }
    }
}
