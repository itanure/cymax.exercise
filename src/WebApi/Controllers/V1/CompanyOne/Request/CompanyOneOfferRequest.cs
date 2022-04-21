namespace WebApi.Controllers.V1.CompanyOne.Request
{
    public class CompanyOneRequest
    {
        public CompanyOneAddress ContactAddress { get; set; }
        public CompanyOneAddress WarehouseAddress { get; set; }
        public PackageDimensions[] Dimensions { get; set; }
    }
}
