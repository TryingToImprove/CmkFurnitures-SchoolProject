using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class UploadImageViewModel
    {
        [Required(ErrorMessage = "Du skal vælge et billede")]
        public HttpPostedFileBase File { get; set; }

        public bool? ProfileImage { get; set; }
    }
}