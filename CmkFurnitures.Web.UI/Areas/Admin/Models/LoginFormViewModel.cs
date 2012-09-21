using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class LoginFormViewModel
    {
        [Required]
        [DisplayName("Brugernavn")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Kodeord")]
        public string Password { get; set; }
    }
}