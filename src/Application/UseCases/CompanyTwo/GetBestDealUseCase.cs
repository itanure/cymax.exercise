using Application.Boundaries.CompanyTwo;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CompanyTwo
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
                Amount = 2
            });
        }
    }
}
