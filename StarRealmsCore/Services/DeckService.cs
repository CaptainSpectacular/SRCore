using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Data;
using StarRealmsCore.Models.Cards;
using StarRealmsCore.Models.Decks;

namespace StarRealmsCore.Services
{
    public class DeckService
    {
        readonly AppDbContext _context;

        public DeckService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateDeck(DeckCreateCommand command)
        {
            var deck = command.ToDeck();
            _context.Decks.Add(deck);
            _context.SaveChanges();

            AddDefaultCards(deck.Id);
        }

        private void AddDefaultCards(int id)
        {
            var corvette = new DeckCard
            {
                CardId = 1,
                DeckId = id,
                Quantity = 8
            };
            var viper = new DeckCard
            {
                CardId = 2,
                DeckId = id,
                Quantity = 2
            };
            _context.DeckCards.Add(corvette);
            _context.DeckCards.Add(viper);
            _context.SaveChanges();
        }

        public DeckViewModel GetDeck(int id)
        {
            return _context.Decks.Where(deck => deck.Id == id)
                .Select(deck => new DeckViewModel
                {
                    Id = deck.Id,
                    PlayerId = deck.PlayerId,
                    GameId = deck.GameId,
                    Type = deck.Type,
                    Cards = deck.DeckCards.Join(_context.Cards,
                        dc => dc.CardId,
                        card => card.Id,
                        (dc, card) => new CardViewModel
                        {
                            Name = card.Name,
                            Cost = card.Cost,
                            Quantity = dc.Quantity
                        })
                        .ToList()
                })
                .SingleOrDefault();
        }
    }
}
