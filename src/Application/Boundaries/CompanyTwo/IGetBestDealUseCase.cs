using MediatR;

namespace Application.Boundaries.CompanyTwo
{
    public interface IGetBestDealUseCase : 
        IRequestHandler<GetBestDealInput, GetBestDealOutput>
    {
    }
}
