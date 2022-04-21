using ContractTests.Mocks;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using WebApi;
using Xunit;

namespace ContractTests.Configuration
{
    [ExcludeFromCodeCoverage]
    [CollectionDefinition(nameof(TestFixtureCollection))]
    public class TestFixtureCollection : ICollectionFixture<TestFixture<Startup>> { }

    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        private bool _disposed;

        public readonly AppServicesMock AppServicesMock;
        public readonly AppFactory<TStartup> Factory;
        public readonly HttpClient Client;

        public TestFixture()
        {
            AppServicesMock = new AppServicesMock();
            Factory = new AppFactory<TStartup>(AppServicesMock);
            Client = Factory.CreateClient();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Client?.Dispose();
            }

            _disposed = true;
        }
    }
}
