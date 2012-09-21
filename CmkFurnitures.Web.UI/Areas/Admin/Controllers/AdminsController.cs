using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Web.UI.Areas.Admin.Models;

namespace CmkFurnitures.Web.UI.Areas.Admin.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminsController : BaseController
    {
        protected IAdminService AdminService;
        public AdminsController(IAdminService adminService)
        {
            this.AdminService = adminService;
        }

        //
        // GET: /Admin/Admins/

        public ActionResult Index()
        {
            IEnumerable<Domain.Admin> admins = AdminService.GetAll();

            return View(new IndexAdminsViewModel
            {
                Admins = admins
            });
        }

        //
        // GET: /Admin/Admins/Create

        public ActionResult Create()
        {
            Domain.Admin admin = new Domain.Admin();
            return View(new CreateAdminsViewModel
            {
                AdminForm = new AdminFormViewModel()
            });
        }

        //
        // POST: /Admin/Admins/Create

        [HttpPost]
        public ActionResult Create(CreateAdminsViewModel requestedViewModel)
        {
            if (!string.IsNullOrWhiteSpace(requestedViewModel.AdminForm.UserName) && AdminService.UserNameInUse(requestedViewModel.AdminForm.UserName))
            {
                ModelState.AddModelError("AdminForm.UserName", "Brugernavnet er allerede i brug");
            }

            if (ModelState.IsValid)
            {
                Domain.Admin admin = new Domain.Admin()
                {
                    Author = new Domain.Author
                    {
                        FirstName = requestedViewModel.AdminForm.FirstName,
                        LastName = requestedViewModel.AdminForm.LastName
                    },
                    UserName = requestedViewModel.AdminForm.UserName,
                    Password = requestedViewModel.AdminForm.Password
                };

                AdminService.Create(admin);

                return RedirectToAction("Index");
            }
            return View(requestedViewModel);
        }

        //
        // GET: /Admin/Admins/Delete/1

        public ActionResult Delete(int id)
        {
            Domain.Admin admin = AdminService.GetById(id);

            if (admin.Author.Articles.Any())
            {
                return View("CouldNotDelete");
            }

            AdminService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
