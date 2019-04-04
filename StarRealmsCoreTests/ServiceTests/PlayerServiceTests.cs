using System.Collections.Generic;
using System.Linq;
using StarRealmsCore.Data;
using StarRealmsCore.Services;
using StarRealmsCore.Models.Games;
using StarRealmsCore.Models.Players;
using Xunit;

namespace StarRealmsCoreTests.ServiceTests
{
    public class PlayerServiceTests : IDbConnector
    {
        [Fact]
        public void TestCreatingPlayer()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var service = new PlayerService(context);
                PlayerCreateCommand player1 = new PlayerCreateCommand
                {
                    Name = "ZTO"
                };
                PlayerCreateCommand player2 = new PlayerCreateCommand
                {
                    Name = "CptnSpctlr"
                };

                service.CreatePlayer(player1);
                service.CreatePlayer(player2);

                var result = service.GetPlayers();
                var p1 = service.GetPlayerDetails("ZTO");

                Assert.Equal(2, result.Count());
                Assert.Equal("ZTO", result.First().Name);
                Assert.Equal("CptnSpctlr", result.Last().Name);
            }
        }

        [Fact]
        public void GetPlayersReturnsAllPlayers()
        {

            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var service = new PlayerService(context);
                PlayerCreateCommand player1 = new PlayerCreateCommand
                {
                    Name = "ZTO"
                };
                PlayerCreateCommand player2 = new PlayerCreateCommand
                {
                    Name = "CptnSpctlr"
                };

                service.CreatePlayer(player1);
                service.CreatePlayer(player2);

                var result = service.GetPlayers();

                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public void GetPlayerDetails()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var playerService = new PlayerService(context);
                var gameService = new GameService(context);
                PlayerCreateCommand player = new PlayerCreateCommand
                { Name = "ZTO" };
                GameCreateCommand game1 = new GameCreateCommand();
                GameCreateCommand game2 = new GameCreateCommand(); 
                PlayerGame pg1 = new PlayerGame
                {
                    PlayerId = 1,
                    GameId = 1
                };
                PlayerGame pg2 = new PlayerGame
                {
                    PlayerId = 1,
                    GameId = 2
                };

                playerService.CreatePlayer(player);
                gameService.CreateGame(game1);
                gameService.CreateGame(game2);
                context.PlayerGames.AddRange(pg1, pg2);
                context.SaveChanges();

                var players = playerService.GetPlayerDetails("ZTO");
                var games = players.Games;

                Assert.IsType<PlayerViewModel>(players);
                Assert.IsType<List<GameViewModel>>(players.Games);
                Assert.Equal("ZTO", players.Name);
                Assert.Equal(2, games.Count());
            }
        }

        [Fact]
        public void GetPlayerId()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var service = new PlayerService(context);
                var player = new PlayerCreateCommand
                {
                    Name = "ZTO"
                };
                service.CreatePlayer(player);

                int id = service.GetPlayerId("ZTO");

                Assert.Equal(1, id);
            }
        }
    }
}
