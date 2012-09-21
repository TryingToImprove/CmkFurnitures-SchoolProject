using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Security;

namespace CmkFurnitures.Web.UI.Areas.Admin.Controllers
{
    public abstract class BaseController : Controller
    {
        public new virtual ICustomPrincipal User
        {
            get { return base.User as ICustomPrincipal; }
        }

    }
}
