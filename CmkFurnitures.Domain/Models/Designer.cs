using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain
{
    public partial class Designer
    {
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
