using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Models
{
    public class SearchResultFurnitureViewModel : RootViewModel
    {
        public SearchResultFurnitureViewModel(string currentPageHeader, string menuKey) : base(currentPageHeader, menuKey) { }

        public IEnumerable<Furniture> Results { get; set; }
    }
}