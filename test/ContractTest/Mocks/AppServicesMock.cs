using MediatR;
using Moq;

namespace ContractTests.Mocks
{
    public class AppServicesMock
    {
        public readonly Mock<Application.Boundaries.CompanyOne.IGetBestDealUseCase> CompanyOneGetBestDealUseCaseMock;
        public readonly Mock<Application.Boundaries.CompanyTwo.IGetBestDealUseCase> CompanyTwoGetBestDealUseCaseMock;
        public readonly Mock<Application.Boundaries.CompanyThree.IGetBestDealUseCase> CompanyThreeGetBestDealUseCaseMock;
        public readonly Mock<IMediator> MediatorMock;

        public AppServicesMock()
        {
            CompanyOneGetBestDealUseCaseMock = new Mock<Application.Boundaries.CompanyOne.IGetBestDealUseCase>();
            CompanyTwoGetBestDealUseCaseMock = new Mock<Application.Boundaries.CompanyTwo.IGetBestDealUseCase>();
            CompanyThreeGetBestDealUseCaseMock = new Mock<Application.Boundaries.CompanyThree.IGetBestDealUseCase>();
            MediatorMock = new Mock<IMediator>();
        }

        public Application.Boundaries.CompanyOne.IGetBestDealUseCase CompanyOneGetBestDealUseCase => CompanyOneGetBestDealUseCaseMock.Object;
        public Application.Boundaries.CompanyTwo.IGetBestDealUseCase CompanyTwoGetBestDealUseCase => CompanyTwoGetBestDealUseCaseMock.Object;
        public Application.Boundaries.CompanyThree.IGetBestDealUseCase CompanyThreeGetBestDealUseCase => CompanyThreeGetBestDealUseCaseMock.Object;
        public IMediator Mediator => MediatorMock.Object;

    }
}
