using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class ArticleFormViewModel
    {
        public string AuthorName { get; set; }

        [Required]
        [MaxLength(150)]
        [DisplayName("Overskrift")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Indhold")]
        public string Text { get; set; }
    }
}