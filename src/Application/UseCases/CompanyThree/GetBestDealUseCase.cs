using Application.Boundaries.CompanyThree;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CompanyThree
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
                Quote = 3
            });
        }
    }
}
