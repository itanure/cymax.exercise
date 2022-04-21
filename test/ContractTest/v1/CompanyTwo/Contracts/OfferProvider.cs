using Application.Boundaries.CompanyTwo;

namespace ContractTests.v1.CompanyTwo.Contracts
{
    public class OfferProvider
    {
        public GetBestDealOutput BestDealResponseStatus200 =>
            new GetBestDealOutput { Amount = 1 };

    }
}
