namespace ContractTests.v1.CompanyThree.Contracts
{
    public class OfferContracts
    {
        public OfferContracts()
        {
        }
        public static OfferContracts Request => new OfferContracts();
        public static OfferContracts Response => new OfferContracts();

        public OfferConsumer Consumer = new OfferConsumer();
        public OfferProvider Provider = new OfferProvider();

    }
}
