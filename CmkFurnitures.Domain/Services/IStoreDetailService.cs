using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Models;

namespace CmkFurnitures.Domain.Services
{
    public interface IStoreDetailService
    {
        StoreDetails GetStoreDetails();

        void Update(StoreDetails storeDetails);
    }
}
