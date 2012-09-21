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
        public IEnumerable<FurnitureType> Types { get; set; }

        public int? SelectedDesigner { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Designers { get; set; }

        public MinMax<int?> Year { get; set; }
        public MinMax<decimal?> Price { get; set; }

        public class MinMax<T>
        {
            public T Min { get; set; }
            public T Max { get; set; }
        }
    }
}