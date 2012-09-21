using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Repositories;

namespace CmkFurnitures.Services.Dependencies
{
    public class StoreDetailServiceDependencies
    {
        public IStoreDetailsRepository StoreDetailsRepository { get; set; }
    }
}
