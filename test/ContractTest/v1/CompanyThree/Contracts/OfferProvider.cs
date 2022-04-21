using Application.Boundaries.CompanyThree;

namespace ContractTests.v1.CompanyThree.Contracts
{
    public class OfferProvider
    {
        public GetBestDealOutput BestDealResponseStatus200 =>
            new GetBestDealOutput { Quote = 1 };
        public string BestDealResponseStatus200AsString =>
            @"<GetBestDealOutput xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Quote>1</Quote></GetBestDealOutput>";

    }
}
