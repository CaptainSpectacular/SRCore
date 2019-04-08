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
        
        public void CreateMainDeck(int gameId)
        {
            Deck deck = new Deck
            {
                Type = 2,
                GameId = gameId
            };

            _context.Decks.Add(deck);
            _context.SaveChanges();
            AddCards(deck.Id);
        }

        public void CreateDeck(DeckCreateCommand command)
        {
            var deck = command.ToDeck();
            _context.Decks.Add(deck);
            _context.SaveChanges();
            AddCards(deck.Id, false);
        }

        private void AddCards(int deckId, bool all = true)
        {
            // Change card objects into Dictionary/Hashmap
            IList<Card> cards = _context.Cards
                .Where(card => (all) ? card.Cost != 0 : card.Cost == 0)
                .Select(card => new Card
                {
                    Id = card.Id,
                    DefaultQuantity = card.DefaultQuantity
                })
                .ToList();

            for (int i = 0; i < cards.Count(); i++)
            {
                _context.DeckCards.Add(new DeckCard
                {
                    DeckId = deckId,
                    CardId = cards[i].Id,
                    Quantity = cards[i].DefaultQuantity
                });
            }

            _context.SaveChanges();
        }
    }
}
