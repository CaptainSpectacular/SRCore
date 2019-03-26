using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using StarRealmsCore.Services;
using StarRealmsCore.Data;
using StarRealmsCore.Models.Games;
using Xunit;

namespace StarRealmsCoreTests.ServiceTests
{
    public class GameServiceTests
    {

        [Fact]
        public void TestWriteToDatabase()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var service = new GameService(context);
                GameCreateCommand command1 = new GameCreateCommand 
                {
                    PlayerTurn = 1
                };

                GameCreateCommand command2 = new GameCreateCommand();

                service.CreateGame(command1);
                service.CreateGame(command2);
            }

            using (var context = new AppDbContext(options))
            {
                var result1 = context.Games.Find(1);
                var result2 = context.Games.Find(2);
                
                Assert.Equal(2, context.Games.Count());
                Assert.Equal(1, result1.PlayerTurn); 
                Assert.Equal(0, result2.PlayerTurn); 
            }
        }
    }
}
