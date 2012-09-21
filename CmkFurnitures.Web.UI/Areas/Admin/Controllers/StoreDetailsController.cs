using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Web.UI.Areas.Admin.Models;
using CmkFurnitures.Domain.Models;

namespace CmkFurnitures.Web.UI.Areas.Admin.Controllers
{
    public class StoreDetailsController : BaseController
    {
        IStoreDetailService StoreDetailService;
        public StoreDetailsController(IStoreDetailService storeDetailService)
        {
            this.StoreDetailService = storeDetailService;
        }

        //
        // GET: /Admin/StoreDetails/

        public ActionResult Index()
        {
            StoreDetails storeDetails = StoreDetailService.GetStoreDetails();

            return View(new IndexStoreDetailsViewModel
            {
                StoreDetails = storeDetails,
                Name = storeDetails.Name,
                Address = new IndexStoreDetailsViewModel.AddressInformation
                {
                    Number = storeDetails.Address.Number,
                    Postal = storeDetails.Address.Postal,
                    Road = storeDetails.Address.Road,
                    Town = storeDetails.Address.Town
                },
                Contact = new IndexStoreDetailsViewModel.ContactInformation
                {
                    Email = storeDetails.Contact.Email,
                    Mobilephone = storeDetails.Contact.Mobilephone,
                    Telephone = storeDetails.Contact.Telephone
                }
            });
        }


        //
        // POST: /Admin/StoreDetails/

        [HttpPost]
        public ActionResult Update(IndexStoreDetailsViewModel requestedViewModel)
        {
            List<int> openingHours = new List<int>();
            ValidateOpeningHours(requestedViewModel.OpeningHour, "OpeningHour", ref openingHours);

            List<int> closingHours = new List<int>();
            ValidateOpeningHours(requestedViewModel.CloseingHour, "CloseingHour", ref closingHours);

            if (ModelState.IsValid)
            {
                StoreDetails storeDetails = new StoreDetails();

                storeDetails.Name = requestedViewModel.Name;

                storeDetails.Address = new StoreDetails.AddressInformation
               {
                   Number = requestedViewModel.Address.Number,
                   Postal = requestedViewModel.Address.Postal,
                   Road = requestedViewModel.Address.Road,
                   Town = requestedViewModel.Address.Town
               };

                storeDetails.Contact = new StoreDetails.ContactInformation
                {
                    Email = requestedViewModel.Contact.Email,
                    Mobilephone = requestedViewModel.Contact.Mobilephone,
                    Telephone = requestedViewModel.Contact.Telephone
                };

                for (int i = 0; i < 7; i++)
                {
                    storeDetails.OpeningHours.Add(new StoreDetails.OpeningHour
                    {
                        Day = i,
                        Closeing = closingHours.ElementAt(i),
                        Opening = openingHours.ElementAt(i)
                    });
                }

                StoreDetailService.Update(storeDetails);
            }

            return RedirectToAction("Index");
        }

        private void ValidateOpeningHours(IEnumerable<string> hours, string name, ref List<int> list)
        {
            for (var i = 0; i < hours.Count(); i++)
            {
                string modelName = name + "[" + i + "]", obj = hours.ElementAt(i);

                if (string.IsNullOrWhiteSpace(obj))
                {
                    ModelState.AddModelError(modelName, "Må ikke være tom");
                }

                int openingHour;
                if (!int.TryParse(obj, out openingHour))
                {   
                    ModelState.AddModelError(modelName, "Skal være et heltal");
                }
                else
                {
                    if ((openingHour < 0 || openingHour > 2359) && (openingHour != -1))
                    {
                        ModelState.AddModelError(modelName, "Tallet skal være imellem 0 og 2359");
                    }
                }
                if (ModelState.IsValid)
                {
                    list.Add(openingHour);
                }
            }
        }

    }
}
