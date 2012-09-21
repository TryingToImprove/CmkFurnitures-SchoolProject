using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain
{
    public partial class ImageSize
    {
        public string VirtualPath
        {
            get
            {
                return "~/" + ((this.Path.EndsWith("/")) ? this.Path : this.Path + "/") + this.FileName;
            }
        }
    }
}
