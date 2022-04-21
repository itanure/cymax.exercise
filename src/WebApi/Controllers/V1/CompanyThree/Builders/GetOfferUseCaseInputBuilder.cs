using Application.Boundaries.CompanyThree;
using System.Linq;

namespace WebApi.Controllers.V1.CompanyThree.Builders
{
    public static class GetOfferUseCaseInputBuilder
    {
        public static GetBestDealInput Create() =>
            new GetBestDealInput
            {
                Offer = new Offer()
            };
        public static GetBestDealInput WithSource(this GetBestDealInput input, Request.CompanyThreeAddress source)
        {
            if (source == null)
                return input;

            input.Offer.Source = new Address
            {
                Latitude = source.Latitude,
                Longitude = source.Longitude
            };
            return input;
        }

        public static GetBestDealInput WithDestination(this GetBestDealInput input, Request.CompanyThreeAddress destination)
        {
            if (destination == null)
                return input;

            input.Offer.Destination = new Address
            {
                Latitude = destination.Latitude,
                Longitude = destination.Longitude
            };
            return input;
        }
        public static GetBestDealInput WithPackages(this GetBestDealInput input, Request.Package[] packages)
        {
            if (packages == null)
                return input;

            input.Offer.Packages = packages.Select(d => new Package 
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
