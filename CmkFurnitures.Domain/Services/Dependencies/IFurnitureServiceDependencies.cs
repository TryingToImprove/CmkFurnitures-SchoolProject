using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;

namespace CmkFurnitures.Domain.Services.Dependencies
{
    public interface IFurnitureServiceDependencies
    {
        IFurnitureRepository FurnitureRepository { get; set; }
        IFurnitureTypeRepository FurnitureTypeRepository { get; set; }
        IDesignerRepository DesignerRepository { get; set; }
    }
}
