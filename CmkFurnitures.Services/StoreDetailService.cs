using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmkFurnitures.Domain.Services;
using CmkFurnitures.Services.Dependencies;
using CmkFurnitures.Domain.Models;
using CuttingEdge.Conditions;

namespace CmkFurnitures.Services
{
    public class StoreDetailService : IStoreDetailService
    {
        private StoreDetailServiceDependencies Dependencies;

        public StoreDetailService(StoreDetailServiceDependencies dependencies)
        {
            this.Dependencies = dependencies;
        }

        public StoreDetails GetStoreDetails()
        {
            var storeDetails = Dependencies.StoreDetailsRepository.GetStoreDetails();
            return storeDetails;
        }


        public void Update(StoreDetails storeDetails)
        {
            Condition.Requires(storeDetails).IsNotNull();
            Condition.Requires(storeDetails.Name).IsNotNullOrWhiteSpace();
            Condition.Requires(storeDetails.OpeningHours).IsNotNull().HasLength(7);
            Condition.Requires(storeDetails.Contact).IsNotNull();
            Condition.Requires(storeDetails.Contact.Email).IsNotNullOrWhiteSpace();
            Condition.Requires(storeDetails.Contact.Telephone).IsNotNullOrWhiteSpace();
            Condition.Requires(storeDetails.Address).IsNotNull();
            Condition.Requires(storeDetails.Address.Town).IsNotNullOrWhiteSpace();
            Condition.Requires(storeDetails.Address.Postal).IsInRange(0, 9999);
            Condition.Requires(storeDetails.Address.Number).IsGreaterThan(0);

            Dependencies.StoreDetailsRepository.Update(storeDetails);
        }
    }
}
