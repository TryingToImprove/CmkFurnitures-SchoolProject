using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain.Services;

namespace CmkFurnitures.Services.Dependencies
{
    public class NewsletterServiceDependencies
    {
        public ISubscriberRepository SubscriberRepository { get; set; }
        public IHashService HashService { get; set; }
    }
}
