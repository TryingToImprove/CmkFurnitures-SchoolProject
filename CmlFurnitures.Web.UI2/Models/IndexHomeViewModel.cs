using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Models
{
    public class IndexHomeViewModel : RootViewModel
    {
        public IndexHomeViewModel(string currentPageHeader, string menuKey) : base(currentPageHeader, menuKey) { }

        public IEnumerable<Article> Articles { get; set; }
    }
}