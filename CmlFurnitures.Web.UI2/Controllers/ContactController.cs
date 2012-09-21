using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Web.UI.Models;

namespace CmkFurnitures.Web.UI.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View(new IndexContactViewModel("Kontakt", "contact"));
        }

        //
        // GET: PartialOnly

        [ChildActionOnly]
        public ActionResult Information()
        {
            return PartialView();
        }

    }
}
