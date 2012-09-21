using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Web.UI.Areas.Admin.Models;
using CmkFurnitures.Domain.Services;

namespace CmkFurnitures.Web.UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private IAdminService AdminService;
        public HomeController(IAdminService adminService)
        {
            this.AdminService = adminService;
        }

        //
        // GET: /Admin/Home/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Home/

        public ActionResult Login()
        {
            return View(new LoginFormViewModel
            {
            });
        }

        //
        // POST: /Admin/Home/

        [HttpPost]
        public ActionResult Login(LoginFormViewModel requestedViewModel)
        {
            if (ModelState.IsValid)
            {
                Domain.Admin admin;
                if (AdminService.Validate(requestedViewModel.UserName, requestedViewModel.Password, out admin))
                {
                    AdminService.SignIn(admin, Response);

                    if (admin.IsSystemUser)
                    {
                        return RedirectToAction("Index", "Admins", null);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Brugeren blev ikke fundet");
                }
            }

            return View(requestedViewModel);
        }

        public ActionResult LogOut()
        {
            AdminService.SignOut();

            return RedirectToAction("Login");
        }

        [ChildActionOnly]
        public ActionResult LoginDetails()
        {
            return PartialView("_LoginDetails", new LoginDetailsViewModel
            {
                Name = User.Identity.FirstName + " " + User.Identity.LastName
            });
        }
    }
}
