using System.Collections.Generic;
using System.Linq;
using StarRealmsCore.Data;
using StarRealmsCore.Services;
using StarRealmsCore.Models.Games;
using Xunit;

namespace StarRealmsCoreTests.ServiceTests
{
    public class GameServiceTests : IDbConnector
    {

        [Fact]
        public void TestWriteToDatabase()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var service = new GameService(context);
                GameCreateCommand command1 = new GameCreateCommand(); 
                GameCreateCommand command2 = new GameCreateCommand();

                service.CreateGame(command1);
                service.CreateGame(command2);

                var result1 = context.Games.Find(1);
                var result2 = context.Games.Find(2);
                
                Assert.Equal(2, context.Games.Count());
            }
        }
    }
}
