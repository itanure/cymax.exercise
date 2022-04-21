using Application.Boundaries.CompanyOne;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CompanyOne
{
    public class GetBestDealUseCase : IGetBestDealUseCase
    {

        public GetBestDealUseCase()
        {
        }

        public Task<GetBestDealOutput> Handle(GetBestDealInput request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetBestDealOutput
            {
                Total = 1
            });
        }
    }
}
