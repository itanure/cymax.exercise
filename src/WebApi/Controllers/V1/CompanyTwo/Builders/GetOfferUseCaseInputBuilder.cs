using Application.Boundaries.CompanyTwo;
using System;
using System.Linq;

namespace WebApi.Controllers.V1.CompanyTwo.Builders
{
    public static class GetOfferUseCaseInputBuilder
    {

        public static GetBestDealInput Create() =>
            new GetBestDealInput
            {
                Offer = new Offer()
            };
        public static GetBestDealInput WithConsignee(this GetBestDealInput input, Request.CompanyTwoAddress consignee)
        {
            if (consignee == null)
                return input;

            input.Offer.Consignee = new Address
            {
                Latitude = consignee.Latitude,
                Longitude = consignee.Longitude
            };
            return input;
        }

        public static GetBestDealInput WithConsignor(this GetBestDealInput input, Request.CompanyTwoAddress consignor)
        {
            if (consignor == null)
                return input;

            input.Offer.Consignor = new Address
            {
                Latitude = consignor.Latitude,
                Longitude = consignor.Longitude
            };
            return input;
        }
        public static GetBestDealInput WithCartons(this GetBestDealInput input, Request.CartonsDimension[] cartons)
        {
            if (cartons == null)
                return input;

            input.Offer.Cartons = cartons.Select(d => new CartonsDimension
            {
                Height = d.Height,
                Length = d.Length,
                Weight = d.Weight,
                Width = d.Width
            }).ToArray();

            return input;
        }
    }
}
