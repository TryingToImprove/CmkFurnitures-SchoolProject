using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class IndexFurnituresViewModel
    {
        public IEnumerable<Furniture> Furnitures { get; set; }
    }
}