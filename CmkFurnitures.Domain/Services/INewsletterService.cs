using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Domain.Services
{
    public interface INewsletterService
    {
        void AddSubscriber(string email);
        void RemoveSubscriber(string email);
    }
}
