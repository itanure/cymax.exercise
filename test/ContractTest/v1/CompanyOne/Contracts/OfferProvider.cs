using Application.Boundaries.CompanyOne;

namespace ContractTests.v1.CompanyOne.Contracts
{
    public class OfferProvider
    {
        public GetBestDealOutput BestDealResponseStatus200 =>
            new GetBestDealOutput { Total = 1 };

    }
}
