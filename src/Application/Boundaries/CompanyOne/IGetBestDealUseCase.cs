using MediatR;

namespace Application.Boundaries.CompanyOne
{
    public interface IGetBestDealUseCase : 
        IRequestHandler<GetBestDealInput, GetBestDealOutput>
    {
    }
}
