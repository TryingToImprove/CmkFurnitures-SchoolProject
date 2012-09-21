using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain.Services.Dependencies;

namespace CmkFurnitures.Services.Dependencies
{
    public class ImageServiceDependencies : IImageServiceDependencies
    {
        public IImageRepository ImageRepository { get; set; }
        public IImageSizeRepository ImageSizeRepository { get; set; }
    }
}
