using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace StarRealmsCoreTests.Features
{
    public class BasicIntegration
        : IClassFixture<WebApplicationFactory<StarRealmsCore.Startup>>
    {
        private readonly WebApplicationFactory<StarRealmsCore.Startup> _factory;
        public BasicIntegration(WebApplicationFactory<StarRealmsCore.Startup> factory)
        {
            _factory = factory;
        }
        
        [Theory]
        [InlineData("Games")]
        public async Task TestHomePage(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
