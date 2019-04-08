using System.Collections.Generic;
using System.Linq;
using StarRealmsCore.Data;
using StarRealmsCore.Services;
using StarRealmsCore.Models.Decks;
using StarRealmsCore.Models.Cards;
using Xunit;

namespace StarRealmsCoreTests.ServiceTests
{
    public class DeckServiceTests : IDbConnector
    {
        [Fact]
        public void TestCreatingDeck()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var service = new DeckService(context);
                DeckCreateCommand deck = new DeckCreateCommand
                {
                    GameId = 1,
                    PlayerId = 1,
                    Type = 1
                };

                service.CreateDeck(deck);

                Assert.Equal(1, context.Decks.Count());
            }
        }

        [Fact]
        public void TestDefaultCardsInDeck()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var service = new DeckService(context);
                DeckCreateCommand deck = new DeckCreateCommand
                {
                    GameId = 1,
                    PlayerId = 1,
                    Type = 1
                };
                Card scout = new Card
                {
                    Name = "Scout",
                    Cost = 0,
                    DefaultQuantity = 8
                };
                Card viper = new Card
                {
                    Name = "Viper",
                    Cost = 0,
                    DefaultQuantity = 2
                };
                context.Cards.Add(scout);
                context.Cards.Add(viper);

                service.CreateDeck(deck);

                var d = service.GetDeck(1);
                int totalQuantity = d.Cards.Select(x => x.Quantity).Sum();
                int scoutQuantity = d.Cards.First().Quantity;
                int viperQuantity = d.Cards.Last().Quantity;;
                
                Assert.Equal(2, d.Cards.Count());
                Assert.Equal(10, totalQuantity);
                Assert.Equal(8, scoutQuantity);
                Assert.Equal(2, viperQuantity);
            }
        }

        [Fact]
        public void TestCreatingMainDeck()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                for (int i = 0; i < 20; i++)
                {
                    Card card = new Card
                    {
                        Name = "DummyCard" + i.ToString(),
                        Cost = i,
                        DefaultQuantity = 10 
                    };

                    context.Cards.Add(card);
                    context.SaveChanges();
                }
                Player player1 = new Player { Name = "ZTO" };
                Player player2 = new Player { Name = "CS" };
                context.Players.Add(player1);
                context.Players.Add(player2);
                context.SaveChanges();
                Game game = new Game
                {
                    PlayerTurn = 0
                };
                context.SaveChanges();
                PlayerGame pg1 = new PlayerGame { PlayerId = 1, GameId = 1 };
                PlayerGame pg2 = new PlayerGame { PlayerId = 2, GameId = 1 };
                context.PlayerGames.Add(pg1);
                context.PlayerGames.Add(pg2);
                context.SaveChanges();
                DeckService deckService = new DeckService(context);
                deckService.CreateMainDeck(game.Id);
                var deck = deckService.GetDeck(1);

                int totalCount = deck.Cards.Select(x => x.Quantity).Sum();


                // should not add cards with a cost of 0
                Assert.Equal(19, deck.Cards.Count());
                Assert.Equal(190, totalCount);
            }
        }
    }
}
