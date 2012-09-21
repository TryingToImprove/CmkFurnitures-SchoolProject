using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;
using CmkFurnitures.Domain;

namespace CmkFurnitures.DAL.MSSQL.Repositories
{
    public class SubscriberRepository : BaseRepository, ISubscriberRepository
    {
        public SubscriberRepository(CmkFurnituresDbEntities entities)
            : base(entities)
        {
        }

        public bool Verify(string email)
        {
            return Entities.Subscribers.Any(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Subscriber subscriber)
        {
            Entities.Subscribers.AddObject(subscriber);
            SaveChanges();
        }

        public void Remove(Subscriber subscriber)
        {
            Entities.Subscribers.DeleteObject(subscriber);
            SaveChanges();
        }

        public Subscriber GetById(int id)
        {
            return Entities.Subscribers.SingleOrDefault(x => x.SubscriberId == id);
        }

        public Subscriber GetByEmail(string email)
        {
            return Entities.Subscribers.SingleOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
