using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http;


namespace StarRealmsCoreTests.Features.Games
{
    public class PostGamesTest 
        : IClassFixture<WebApplicationFactory<StarRealmsCore.Startup>>
    {
        readonly WebApplicationFactory<StarRealmsCore.Startup> _factory;

        public PostGamesTest(WebApplicationFactory<StarRealmsCore.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestPostToGames()
        {
            var client = _factory.CreateClient();
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "Player1", "CaptainSpectacular" },
                { "Player2", "Ziltoid the Omniscient" }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("/Games/Create", content);

            Assert.Equal("OK", response.StatusCode.ToString());
        }
    }
}
