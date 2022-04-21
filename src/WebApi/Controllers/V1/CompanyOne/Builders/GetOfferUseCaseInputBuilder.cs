using Application.Boundaries.CompanyOne;
using System;
using System.Linq;

namespace WebApi.Controllers.V1.CompanyOne.Builders
{
    public static class GetOfferUseCaseInputBuilder
    {

        public static GetBestDealInput Create() =>
            new GetBestDealInput
            {
                Offer = new Offer()
            };
        public static GetBestDealInput WithContactAddress(this GetBestDealInput input, Request.CompanyOneAddress contactAddress)
        {
            if (contactAddress == null)
                return input;

            input.Offer.ContactAddress = new Address
            {
                Latitude = contactAddress.Latitude,
                Longitude = contactAddress.Longitude
            };
            return input;
        }

        public static GetBestDealInput WithWarehouseAddress(this GetBestDealInput input, Request.CompanyOneAddress warehouseAddress)
        {
            if (warehouseAddress == null)
                return input;

            input.Offer.WarehouseAddress = new Address
            {
                Latitude = warehouseAddress.Latitude,
                Longitude = warehouseAddress.Longitude
            };
            return input;
        }
        public static GetBestDealInput WithDimensions(this GetBestDealInput input, Request.PackageDimensions[] dimensions)
        {
            if (dimensions == null)
                return input;

            input.Offer.Dimensions = dimensions.Select(d => new PackageDimensions
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
