using System.Collections.Generic;

namespace ContractTests.v1.CompanyOne.Contracts
{
    public class OfferConsumer
    {
        public object OfferCompanyOneStatus200 =>
            new
            {
                ContactAddress = new
                {
                    line1 = "string",
                    line2 = "string",
                    city = "string",
                    zipCode = "string",
                    latitude = 0,
                    longitude = 0
                },
                warehouseAddress = new
                {
                    line1 = "string",
                    line2 = "string",
                    city = "string",
                    zipCode = "string",
                    latitude = 0,
                    longitude = 0
                },
                dimensions = new List<object>
                {
                    new {
                        length = 0,
                        width = 0,
                        height = 0,
                        weight = 0
                    }, new {
                        length = 0,
                        width = 0,
                        height = 0,
                        weight = 0
                    }
                }
            };
    }
}
