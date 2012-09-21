using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Models;

namespace CmkFurnitures.Domain.Repositories
{
    public interface IStoreDetailsRepository
    {
        StoreDetails GetStoreDetails();

        void Update(StoreDetails storeDetails);
    }
}
