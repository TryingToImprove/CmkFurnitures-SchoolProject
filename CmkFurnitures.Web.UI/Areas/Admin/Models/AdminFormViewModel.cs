using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class AdminFormViewModel
    {
        [Required]
        [DisplayName("Brugernavn")]
        public string UserName { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "Dit kodeord skal være på mindst 7 tegn")]
        [DataType(DataType.Password)]
        [DisplayName("Kodeord")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Kodeordne er ikke ens")]
        [DataType(DataType.Password)]
        [DisplayName("Gentag kodeord")]
        public string RepeatedPassword { get; set; }

        [Required]
        [DisplayName("Fornavn")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Efternavn")]
        public string LastName { get; set; }
    }
}
