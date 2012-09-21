using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Domain;
using System.Web;
using CmkFurnitures.Domain.Services.Dependencies;
using System.IO;
using System.Drawing;
using CuttingEdge.Conditions;
using CmkFurnitures.Domain.Models;

namespace CmkFurnitures.Services
{
    public class ImageService : IImageService
    {
        private IImageServiceDependencies Dependencies;
        private HttpContext HttpContext;

        private const string UploadPath = "/Content/Uploads/Furnitures/";

        public ImageService(IImageServiceDependencies dependencies, HttpContext httpContext)
        {
            this.Dependencies = dependencies;
            this.HttpContext = httpContext;
        }

        public Domain.Image Upload(HttpPostedFileBase file, Furniture furniture)
        {
            Condition.Requires(file).IsNotNull();
            Condition.Requires(file.ContentLength).IsGreaterThan(0);
            Condition.Requires(file.FileName).IsNotNullOrWhiteSpace();

            Condition.Requires(furniture).IsNotNull();
            Condition.Requires(furniture.PartNumber).IsNotNullOrWhiteSpace();

            string path, fileName;

            UploadImage(file, furniture, out path, out fileName);

            Domain.Image image = Dependencies.ImageRepository.Add(
                new Domain.Image()
                {
                    Path = UploadPath + path,
                    FileName = fileName
                }, furniture);

            return image;
        }

        private void UploadImage(HttpPostedFileBase file, Furniture furniture, out string path, out string fileName)
        {
            path = furniture.PartNumber + "/" + "Original/";
            fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            CreateDirectory(GetVirtualPath(path));

            file.SaveAs(Path.Combine(GetVirtualPath(path), fileName));
        }

        public void Resize(Domain.Image image, ImageSizeSpecification sizeSpec, Furniture furniture)
        {
            ResizeAndSave(image, furniture, sizeSpec.Width, sizeSpec.Height);
        }

        public void Resize(Domain.Image image, IEnumerable<ImageSizeSpecification> sizeSpecs, Furniture furniture)
        {
            foreach (var sizeSpec in sizeSpecs)
            {
                ResizeAndSave(image, furniture, sizeSpec.Width, sizeSpec.Height);
            }
        }

        private void ResizeAndSave(Domain.Image image, Furniture furniture, int width, int height)
        {
            using (System.Drawing.Image img = System.Drawing.Image.FromFile(GetVirtualPath(image.VirtualPath)))
            {
                using (Bitmap bitmap = new Bitmap(width, height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        graphics.DrawImage(img, new Rectangle(0, 0, width, height));
                    }


                    string resizedPath = furniture.PartNumber + "/" + width + "x" + height;

                    CreateDirectory(GetVirtualPath(resizedPath));

                    bitmap.Save(GetVirtualPath(resizedPath) + "/" + image.FileName);

                    Dependencies.ImageSizeRepository.Add(new ImageSize
                    {
                        FileName = image.FileName,
                        Path = UploadPath + resizedPath,
                        Height = height,
                        Width = width,
                        ImageId = image.ImageId
                    });
                }
            }
        }

        private string GetVirtualPath(string path)
        {
            if (path.StartsWith("~/" + UploadPath))
                return HttpContext.Server.MapPath(path);
            else
                return HttpContext.Server.MapPath("~/" + UploadPath + path);
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }


        public Domain.Image GetById(int id)
        {
            return Dependencies.ImageRepository.GetById(id);
        }


        public void Delete(Domain.Image image)
        {
            List<ImageSize> imageSizez = image.ImageSizes.ToList();

            foreach (var imageSize in imageSizez)
            {
                File.Delete(GetVirtualPath(imageSize.VirtualPath));
                Dependencies.ImageSizeRepository.Delete(imageSize);
            }

            File.Delete(GetVirtualPath(image.VirtualPath));
            Dependencies.ImageRepository.Delete(image);
        }
    }
}
