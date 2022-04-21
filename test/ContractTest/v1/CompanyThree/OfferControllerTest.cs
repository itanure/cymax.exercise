using Application.Boundaries.CompanyThree;
using ContractTests.Configuration;
using ContractTests.v1.CompanyThree.Contracts;
using FluentAssertions;
using MediatR;
using Moq;
using Shared.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApi;
using Xunit;

namespace ContractTests.v1.CompanyThree
{
    [Collection(nameof(TestFixtureCollection))]
    public class OfferControllerTest : IClassFixture<TestFixture<FakeStartupForTests>>
    {

        private const string Endpoint = "v1/companythree/offers";
        private readonly TestFixture<FakeStartupForTests> _testFixture;
        private readonly Mock<IMediator> _mediator;

        public OfferControllerTest(TestFixture<FakeStartupForTests> testFixture)
        {
            _testFixture = testFixture;
            _mediator = testFixture.AppServicesMock.MediatorMock;
        }

        [Fact(DisplayName = "Should Return Same Contract Provider And Consumer")]
        [Trait("CompanyThree", "GetBestDeal - v1")]
        public async Task ShouldReturnSameContractProviderAndConsumer()
        {
            // Arrange
            var consumerContract = OfferContracts.Request.Consumer.OfferCompanyThreeStatus200;
            var providerContract = OfferContracts.Response.Provider.BestDealResponseStatus200;
            var providerContractAsString = OfferContracts.Response.Provider.BestDealResponseStatus200AsString;

            _mediator.Setup(m => m.Send(It.IsAny<GetBestDealInput>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(providerContract);

            var httpContent = new HttpRequestMessage(HttpMethod.Post, Endpoint)
            {
                Content = new StringContent(consumerContract, Encoding.UTF8, "application/xml")
            };

            //Act
            var httpResponseMessage = await _testFixture.Client.SendAsync(httpContent);
            var response = await httpResponseMessage.Content.ReadAsStringAsync();

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            providerContractAsString.Should().BeEquivalentTo(response);
        }

        ///... TODO: implement others statuscode Consumer/Provider
    }
}

