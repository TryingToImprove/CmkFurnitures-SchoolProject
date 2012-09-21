using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Models
{
    public class IndexContactViewModel : RootViewModel
    {
        public IndexContactViewModel(string currentPageHeader, string menuKey) : base(currentPageHeader, menuKey) { }

        public SendMailFormViewModel MailForm { get; set; }
        public Domain.Models.StoreDetails StoreDetails { get; set; }
    }
}