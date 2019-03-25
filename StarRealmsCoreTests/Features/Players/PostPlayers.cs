using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace StarRealmsCoreTests.Features.Players
{
    public class PostPlayersTest
        : IClassFixture<WebApplicationFactory<StarRealmsCore.Startup>>
    {
        readonly WebApplicationFactory<StarRealmsCore.Startup> _factory;
        public PostPlayersTest(WebApplicationFactory<StarRealmsCore.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void TestPostToPlayersCreate()
        {
            var client = _factory.CreateClient();
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "Name", "ZTO" }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("/Players/Create", content);

            Assert.Equal("OK", response.StatusCode.ToString());
        }
    }
}
