using MediatR;

namespace Application.Boundaries.CompanyThree
{
    public interface IGetBestDealUseCase : 
        IRequestHandler<GetBestDealInput, GetBestDealOutput>
    {
    }
}
