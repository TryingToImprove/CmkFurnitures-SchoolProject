using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Services.Dependencies;
using CmkFurnitures.Domain;

namespace CmkFurnitures.Services
{
    public class NewsletterService : INewsletterService
    {
        NewsletterServiceDependencies Dependencies;

        public NewsletterService(NewsletterServiceDependencies dependencies)
        {
            this.Dependencies = dependencies;
        }

        public void AddSubscriber(string email)
        {
            if (!this.Dependencies.SubscriberRepository.Verify(email))
            {
                this.Dependencies.SubscriberRepository.Add(new Subscriber
                {
                    Email = email,
                    Secret = CreateSecret()
                });
            }
        }

        public Subscriber GetById(int id)
        {
            return this.Dependencies.SubscriberRepository.GetById(id);
        }

        public Subscriber GetByEmail(string email)
        {
            return this.Dependencies.SubscriberRepository.GetByEmail(email);
        }

        public void RemoveSubscriber(string email)
        {
            if (this.Dependencies.SubscriberRepository.Verify(email))
            {
                this.Dependencies.SubscriberRepository.Remove(GetByEmail(email));
            }
        }

        private string CreateSecret()
        {
            return this.Dependencies.HashService.CreateHash(Guid.NewGuid().ToString(), "MD5");
        }
    }
}
