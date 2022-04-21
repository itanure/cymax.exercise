using System.Collections.Generic;

namespace ContractTests.v1.CompanyThree.Contracts
{
    public class OfferConsumer
    {
        public string OfferCompanyThreeStatus200 =>
			@"<?xml version=""1.0"" encoding=""UTF-8""?>
				<CompanyThreeRequest>
					<Source>
						<Line1>string</Line1>
						<Line2>string</Line2>
						<City>string</City>
						<ZipCode>string</ZipCode>
						<Latitude>0</Latitude>
						<Longitude>0</Longitude>
					</Source>
					<Destination>
						<Line1>string</Line1>
						<Line2>string</Line2>
						<City>string</City>
						<ZipCode>string</ZipCode>
						<Latitude>0</Latitude>
						<Longitude>0</Longitude>
					</Destination>
					<Packages>
						<Package>
								<Length>0</Length>
								<Width>0</Width>
								<Height>0</Height>
								<Weight>0</Weight>
						</Package>
					</Packages>
				</CompanyThreeRequest>";
    }
}
