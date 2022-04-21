using MediatR;

namespace Application.Boundaries.CompanyOne
{
    public class GetBestDealInput : IRequest<GetBestDealOutput>
    {
        public Offer Offer { get; set; }
    }
    public class Offer
    {
        public Address ContactAddress { get; set; }
        public Address WarehouseAddress { get; set; }
        public PackageDimensions[] Dimensions { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
    public class PackageDimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
