using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmkFurnitures.Domain.Services;

namespace CmkFurnitures.Web.UI.Controllers
{
    public class SubscriberController : Controller
    {
        INewsletterService NewsletterService;

        public SubscriberController(INewsletterService newsletterService)
        {
            this.NewsletterService = newsletterService;
        }

        //
        // POST: /Subscriber/Add

        [HttpPost]
        public ActionResult Add(string email)
        {
            NewsletterService.AddSubscriber(email);

            return Json("success");
        }

        //
        // POST: /Subscriber/Remove

        [HttpPost]
        public ActionResult Remove(string email)
        {
            NewsletterService.RemoveSubscriber(email);

            return Json("success");
        }

    }
}
