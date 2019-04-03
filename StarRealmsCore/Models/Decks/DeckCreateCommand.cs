using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Data;

namespace StarRealmsCore.Models.Decks
{
    public class DeckCreateCommand
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Type { get; set; }

        public Deck ToDeck()
        {
            return new Deck
            {
                PlayerId = PlayerId,
                GameId = GameId,
                Type = Type
            };
        }
    }
}
