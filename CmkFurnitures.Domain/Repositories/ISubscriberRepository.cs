using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Repositories
{
    public interface ISubscriberRepository : IGenericRepository<Subscriber>
    {
        bool Verify(string email);

        void Add(Subscriber subscriber);

        void Remove(Subscriber subscriber);

        Subscriber GetById(int id);

        Subscriber GetByEmail(string email);
    }
}
