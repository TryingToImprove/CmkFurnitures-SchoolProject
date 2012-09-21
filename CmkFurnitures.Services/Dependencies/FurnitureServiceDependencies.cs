using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services.Dependencies;

namespace CmkFurnitures.Services.Dependencies
{
    public class FurnitureServiceDependencies : IFurnitureServiceDependencies
    {
        public Domain.Repositories.IFurnitureRepository FurnitureRepository { get; set; }
        public Domain.Repositories.IFurnitureTypeRepository FurnitureTypeRepository { get; set; }
        public Domain.Repositories.IDesignerRepository DesignerRepository { get; set; }
    }
}
