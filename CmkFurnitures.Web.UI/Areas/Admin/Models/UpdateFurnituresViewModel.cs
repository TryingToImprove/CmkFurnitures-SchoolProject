﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Web.UI.Areas.Admin.Models
{
    public class UpdateFurnituresViewModel
    {
        public Furniture Furniture { get; set; }
        public FurnitureFormViewModel FurnitureForm { get; set; }
    }
}