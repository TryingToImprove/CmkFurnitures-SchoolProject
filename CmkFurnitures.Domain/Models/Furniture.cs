using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain
{
    public partial class Furniture
    {
        public Image ProfileImage
        {
            get
            {
                if (this.Images == null || this.Images.Count() == 0)
                {
                    return null;
                }

                return this.Images.FirstOrDefault(x => x.ImageId == this.ProfileImageId);
            }
        }
    }
}
