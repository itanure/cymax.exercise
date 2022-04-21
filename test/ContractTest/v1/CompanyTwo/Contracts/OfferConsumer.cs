using System.Collections.Generic;

namespace ContractTests.v1.CompanyTwo.Contracts
{
    public class OfferConsumer
    {
        public object OfferCompanyTwoStatus200 =>
                    new
                    {
                        Consignee = new
                        {
                            line1 = "string",
                            line2 = "string",
                            city = "string",
                            zipCode = "string",
                            latitude = 0,
                            longitude = 0
                        },
                        Consignor = new
                        {
                            line1 = "string",
                            line2 = "string",
                            city = "string",
                            zipCode = "string",
                            latitude = 0,
                            longitude = 0
                        },
                        Cartons = new List<object>
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
