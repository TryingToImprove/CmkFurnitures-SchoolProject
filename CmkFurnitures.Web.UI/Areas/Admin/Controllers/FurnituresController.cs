using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CmkFurnitures.Web.UI.Areas.Admin.Models;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Domain;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CmkFurnitures.Web.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class FurnituresController : BaseController
    {
        protected IFurnitureService FurnitureService;
        protected IImageService ImageService;

        public FurnituresController(IFurnitureService funitureService, IImageService imageService)
        {
            this.FurnitureService = funitureService;
            this.ImageService = imageService;
        }

        //
        // GET: /Admin/Furnitures/

        public ActionResult Index()
        {
            return View(new IndexFurnituresViewModel
            {
                Furnitures = FurnitureService.GetAll()
            });
        }

        //
        // GET: /Admin/Furnitures/Create

        public ActionResult Create()
        {
            return View(new CreateFurnituresViewModel
            {
                FurnitureForm = new FurnitureFormViewModel
                {
                    Designers = FurnitureService.GetDesigners().Select(designer => new SelectListItem
                    {
                        Text = designer.FullName,
                        Value = designer.DesignerId.ToString()
                    }),
                    Types = FurnitureService.GetTypes().Select(furnitureType => new SelectListItem
                    {
                        Text = furnitureType.Name,
                        Value = furnitureType.FurnitureTypeId.ToString()
                    }),
                }
            });
        }

        //
        // POST: /Admin/Furnitures/Create

        [HttpPost]
        public ActionResult Create(CreateFurnituresViewModel requestedViewModel)
        {
            if (ModelState.IsValid)
            {
                Furniture furniture = Mapper.Map<FurnitureFormViewModel, Furniture>(requestedViewModel.FurnitureForm);

                FurnitureService.Create(furniture);

                Image image = ImageService.Upload(requestedViewModel.ProfileImage, furniture);
                ImageService.Resize(image, FurnitureService.ImageSizes, furniture);

                FurnitureService.SetProfileImage(furniture, image);

                return RedirectToAction("Update", new { id = furniture.FurnitureId });
            }

            requestedViewModel.FurnitureForm.Designers = FurnitureService.GetDesigners().Select(designer => new SelectListItem
            {
                Text = designer.FullName,
                Value = designer.DesignerId.ToString()
            });
            requestedViewModel.FurnitureForm.Types = FurnitureService.GetTypes().Select(furnitureType => new SelectListItem
            {
                Text = furnitureType.Name,
                Value = furnitureType.FurnitureTypeId.ToString()
            });

            return View(requestedViewModel);
        }

        //
        // GET: /Admin/Furnitures/Update/1

        public ActionResult Update(int id)
        {
            Furniture furniture = FurnitureService.GetById(id);

            FurnitureFormViewModel formViewModel = GenerateFurnitureFormViewModel();
            Mapper.Map<Furniture, FurnitureFormViewModel>(furniture, formViewModel);

            if (TempData["ModelStateFile"] != null)
            {
                foreach (var item in (IEnumerable<KeyValuePair<string, ModelState>>)TempData["ModelStateFile"])
                {
                    ModelState.Add(item);
                }
            }

            return View(new UpdateFurnituresViewModel
            {
                Furniture = furniture,
                FurnitureForm = formViewModel
            });
        }

        //
        // POST: /Admin/Furnitures/Update/1

        [HttpPost]
        public ActionResult Update(int id, UpdateFurnituresViewModel requestedViewModel)
        {
            Furniture furniture = FurnitureService.GetById(id);

            if (ModelState.IsValid)
            {
                Mapper.Map<FurnitureFormViewModel, Furniture>(requestedViewModel.FurnitureForm, furniture);

                FurnitureService.Update(furniture);

                return RedirectToAction("Update", new { id = id });
            }

            requestedViewModel.Furniture = furniture;
            requestedViewModel.FurnitureForm.Designers = FurnitureService.GetDesigners().Select(designer => new SelectListItem
            {
                Text = designer.FullName,
                Value = designer.DesignerId.ToString()
            });
            requestedViewModel.FurnitureForm.Types = FurnitureService.GetTypes().Select(furnitureType => new SelectListItem
            {
                Text = furnitureType.Name,
                Value = furnitureType.FurnitureTypeId.ToString()
            });

            return View(requestedViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Furniture furniture = FurnitureService.GetById(id);

            List<Image> images = furniture.Images.ToList();
            foreach (int imageId in images.Select(x => x.ImageId))
            {
                Image image = ImageService.GetById(imageId);
                ImageService.Delete(image);
            }

            FurnitureService.Delete(furniture);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadImage(int id, UploadImageViewModel requestedViewModel)
        {
            if (ModelState.IsValid)
            {
                string[] authorziedContentTypes = new string[]{
                    "image/gif", "image/png", "image/jpeg", "image/pjpeg"};

                string contentType = getMimeFromFile(requestedViewModel.File);
                if (!authorziedContentTypes.Any(x => x.Equals(contentType, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("File", "Du må kun uploade .gif, .png og .jpg");
                }

                if (ModelState.IsValid)
                {
                    Furniture furniture = FurnitureService.GetById(id);

                    Image image = ImageService.Upload(requestedViewModel.File, furniture);
                    ImageService.Resize(image, FurnitureService.ImageSizes, furniture);

                    if (requestedViewModel.ProfileImage.HasValue && requestedViewModel.ProfileImage.Value)
                        FurnitureService.SetProfileImage(furniture, image);

                    return new RedirectResult(Url.Action("Update", new { id = id }) + "#images");
                }
            }

            TempData["ModelStateFile"] = ModelState.Where(x => x.Key == "File");
            return new RedirectResult(Url.Action("Update", new { id = id }) + "#images");
        }

        public ActionResult UpdateImage(int id, int imageId)
        {
            Furniture furniture = FurnitureService.GetById(id);

            FurnitureService.SetProfileImage(furniture, ImageService.GetById(imageId));

            return new RedirectResult(Url.Action("Update", new { id = id }) + "#images");
        }

        public ActionResult DeleteImage(int id, int imageId)
        {
            Image image = ImageService.GetById(imageId);
            ImageService.Delete(image);

            return new RedirectResult(Url.Action("Update", new { id = id }) + "#images");
        }

        private FurnitureFormViewModel GenerateFurnitureFormViewModel()
        {
            return new FurnitureFormViewModel
            {
                Designers = FurnitureService.GetDesigners().Select(designer => new SelectListItem
                {
                    Text = designer.FullName,
                    Value = designer.DesignerId.ToString()
                }),
                Types = FurnitureService.GetTypes().Select(furnitureType => new SelectListItem
                {
                    Text = furnitureType.Name,
                    Value = furnitureType.FurnitureTypeId.ToString()
                }),
            };
        }

        [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
        static extern int FindMimeFromData(IntPtr pBC,
            [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)] byte[] pBuffer,
            int cbSize,
            [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
            int dwMimeFlags, out IntPtr ppwzMimeOut, int dwReserved);

        public static string getMimeFromFile(HttpPostedFileBase file)
        {
            IntPtr mimeout;

            int MaxContent = (int)file.ContentLength;
            if (MaxContent > 4096) MaxContent = 4096;

            byte[] buf = new byte[MaxContent];
            file.InputStream.Read(buf, 0, MaxContent);
            int result = FindMimeFromData(IntPtr.Zero, file.FileName, buf, MaxContent, null, 0, out mimeout, 0);

            if (result != 0)
            {
                Marshal.FreeCoTaskMem(mimeout);
                return "";
            }

            string mime = Marshal.PtrToStringUni(mimeout);
            Marshal.FreeCoTaskMem(mimeout);

            return mime.ToLower();
        }
    }
}
