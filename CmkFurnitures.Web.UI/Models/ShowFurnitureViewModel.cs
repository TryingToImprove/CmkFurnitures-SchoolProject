using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Models
{
    public class ShowFurnitureViewModel : RootViewModel
    {
        public ShowFurnitureViewModel(string currentPageHeader, string menuKey)
            : base(currentPageHeader, menuKey)
        {
        }

        public Furniture Furniture { get; set; }
    }
}