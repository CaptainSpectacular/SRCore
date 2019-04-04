using System.Collections.Generic;
using System.Linq;
using StarRealmsCore.Data;
using StarRealmsCore.Services;
using StarRealmsCore.Models.Games;
using StarRealmsCore.Models.Players;
using StarRealmsCore.Models.Decks;
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

        [Fact]
        public void CreatePlayerGame()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                PlayerService playerService = new PlayerService(context);
                GameService gameService = new GameService(context);
                playerService.CreatePlayer(new PlayerCreateCommand
                {
                    Name = "ZTO"
                });

                playerService.CreatePlayer(new PlayerCreateCommand
                {
                    Name = "CS"
                });
                
                var gcCommand = new GameCreateCommand
                {
                    ChallengerId = 1,
                    TargetId = 2
                };

                int gameId = gameService.CreateGame(gcCommand);
                gcCommand.Id = gameId;

                gameService.CreatePlayerGames(gcCommand);

                var expected1 = playerService.GetPlayerDetails("ZTO");
                var expected2 = playerService.GetPlayerDetails("CS");

                Assert.Equal(2, context.PlayerGames.Count());
                Assert.Equal(1, expected1.Games.Count());
                Assert.Equal(1, expected2.Games.Count());
            }
        }

    }
}
