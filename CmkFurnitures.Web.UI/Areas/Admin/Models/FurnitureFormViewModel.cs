using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class FurnitureFormViewModel
    {
        [Required]
        [DisplayName("Varenummer")]
        public string PartNumber { get; set; }

        [Required]
        [DisplayName("Designer")]
        public int DesignerId { get; set; }

        [Required]
        [DisplayName("Type")]
        public int FurnitureTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Navn")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Indhold")]
        public string Text { get; set; }

        [Required]
        [DisplayName("Pris")]
        public decimal Price { get; set; }

        [Required]
        [Range(1500, 2100)]
        [DisplayName("Årgang")]
        public int DesignYear { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Designers { get; set; }
    }
}