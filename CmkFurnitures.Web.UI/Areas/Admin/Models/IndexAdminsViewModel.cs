using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class IndexAdminsViewModel
    {
        public IEnumerable<Domain.Admin> Admins { get; set; }
    }
}