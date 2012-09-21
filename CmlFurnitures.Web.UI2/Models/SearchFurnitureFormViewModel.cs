using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;
using System.Web.Mvc;

namespace CmkFurnitures.Web.UI.Models
{
    public class SearchFurnitureFormViewModel
    {
        public string PartNumber { get; set; }

        public IEnumerable<int> SelectedTypes { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }

        public IEnumerable<int> SelectedDesigner { get; set; }
        public IEnumerable<SelectListItem> Designers { get; set; }

        public MinMax<int> Year { get; set; }
        public MinMax<double> Price { get; set; }

        public class MinMax<T>
        {
            public T Min { get; set; }
            public T Max { get; set; }
        }
    }
}