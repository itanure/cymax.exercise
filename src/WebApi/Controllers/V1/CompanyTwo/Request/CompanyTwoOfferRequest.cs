namespace WebApi.Controllers.V1.CompanyTwo.Request
{
    public class CompanyTwoOfferRequest
    {
        public CompanyTwoAddress Consignee { get; set; }
        public CompanyTwoAddress Consignor { get; set; }
        public CartonsDimension[] Cartons { get; set; }
    }
}
