namespace VacationRental.Contact.Api.Tests
{
    using System;
    using System.Net.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;

    [CollectionDefinition("Integration")]
    public class IntegrationFixture : IDisposable, ICollectionFixture<IntegrationFixture>
    {
        private readonly TestServer _server;

        public IntegrationFixture()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = _server.CreateClient();
        }

        public HttpClient Client { get; }

        public Random Random { get; } = new Random();

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
