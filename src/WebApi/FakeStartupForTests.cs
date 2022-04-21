using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class FakeStartupForTests : Startup
    {

        public FakeStartupForTests(IConfiguration configuration) : base(configuration) { }

    }
}
