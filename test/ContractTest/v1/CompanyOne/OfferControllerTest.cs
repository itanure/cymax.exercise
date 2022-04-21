using Application.Boundaries.CompanyOne;
using ContractTests.Configuration;
using ContractTests.v1.CompanyOne.Contracts;
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

namespace ContractTests.v1.CompanyOne
{
    [Collection(nameof(TestFixtureCollection))]
    public class OfferControllerTest : IClassFixture<TestFixture<FakeStartupForTests>>
    {

        private const string Endpoint = "v1/companyone/offers";
        private readonly TestFixture<FakeStartupForTests> _testFixture;
        private readonly Mock<IMediator> _mediator;

        public OfferControllerTest(TestFixture<FakeStartupForTests> testFixture)
        {
            _testFixture = testFixture;
            _mediator = testFixture.AppServicesMock.MediatorMock;
        }

        [Fact(DisplayName = "Should Return Same Contract Provider And Consumer")]
        [Trait("CompanyOne", "GetBestDeal - v1")]
        public async Task ShouldReturnSameContractProviderAndConsumer()
        {
            // Arrange
            var consumerContract = OfferContracts.Request.Consumer.OfferCompanyOneStatus200.ReadAsString();
            var providerContract = OfferContracts.Response.Provider.BestDealResponseStatus200;

            _mediator.Setup(m => m.Send(It.IsAny<GetBestDealInput>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(providerContract);

            var httpContent = new HttpRequestMessage(HttpMethod.Post, Endpoint)
            {
                Content = new StringContent(consumerContract, Encoding.UTF8, "application/json")
            };

            //Act
            var httpResponseMessage = await _testFixture.Client.SendAsync(httpContent);
            var response = await httpResponseMessage.Content.ReadAsStringAsync();

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            providerContract.ReadAsString().Should().BeEquivalentTo(response);
        }

        ///... TODO: implement others statuscode Consumer/Provider
    }
}

