using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain
{
    public partial class Image
    {
        public string VirtualPath
        {
            get
            {
                return "~/" + ((this.Path.EndsWith("/")) ? this.Path : this.Path + "/") + this.FileName;
            }
        }

        public ImageSize GetResizedImage(int width, int height)
        {
            if (this.ImageSizes == null || this.ImageSizes.Count() == 0)
            {
                return null;
            }

            return this.ImageSizes.FirstOrDefault(x => x.Width == width && x.Height == height);
        }
    }
}
