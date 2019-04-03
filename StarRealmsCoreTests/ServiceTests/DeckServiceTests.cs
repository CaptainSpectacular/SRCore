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
                Card corvette = new Card
                {
                    Name = "Corvette",
                    Cost = 0
                };
                Card viper = new Card
                {
                    Name = "Viper",
                    Cost = 0
                };
                context.Cards.Add(viper);
                context.Cards.Add(corvette);

                service.CreateDeck(deck);

                var d = service.GetDeck(1);
                int totalQuantity = d.Cards.Select(x => x.Quantity).Sum();
                int cQuantity = d.Cards.First().Quantity;
                int vQuantity = d.Cards.Last().Quantity;;
                
                Assert.Equal(2, d.Cards.Count());
                Assert.Equal(10, totalQuantity);
                Assert.Equal(8, cQuantity);
                Assert.Equal(2, vQuantity);
            }
        }
    }
}
