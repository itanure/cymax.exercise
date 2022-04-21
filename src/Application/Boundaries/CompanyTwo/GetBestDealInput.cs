using MediatR;

namespace Application.Boundaries.CompanyTwo
{
    public class GetBestDealInput : IRequest<GetBestDealOutput>
    {
        public Offer Offer { get; set; }
    }
    public class Offer
    {
        public Address Consignee { get; set; }
        public Address Consignor { get; set; }
        public CartonsDimension[] Cartons { get; set; }
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
    public class CartonsDimension
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
