using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Models
{
    public class SearchFurnitureViewModel : RootViewModel
    {
        public SearchFurnitureViewModel(string currentPageHeader, string menuKey) : base(currentPageHeader, menuKey) { }

        public SearchFurnitureFormViewModel SearchForm { get; set; }
    }
}