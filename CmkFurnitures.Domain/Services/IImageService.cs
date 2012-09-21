using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CmkFurnitures.Domain.Models;

namespace CmkFurnitures.Domain.Services
{
    public interface IImageService
    {
        Image Upload(HttpPostedFileBase file, Furniture furniture);

        void Resize(Image image, ImageSizeSpecification sizeSpec, Furniture furniture);
        void Resize(Image image, IEnumerable<ImageSizeSpecification> sizeSpecs, Furniture furniture);

        Image GetById(int id);

        void Delete(Image image);
    }
}
