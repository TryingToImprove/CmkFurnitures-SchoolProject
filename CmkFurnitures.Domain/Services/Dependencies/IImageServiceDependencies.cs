using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Services.Dependencies
{
    public interface IImageServiceDependencies
    {
        CmkFurnitures.Domain.Repositories.IImageRepository ImageRepository { get; set; }
        CmkFurnitures.Domain.Repositories.IImageSizeRepository ImageSizeRepository { get; set; }
    }
}
