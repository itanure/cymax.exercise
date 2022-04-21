namespace WebApi.Controllers.V1.CompanyOne.Request
{
    public class CompanyOneAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

    }
}
