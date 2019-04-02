using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class DeckCard
    {
        public int Quantity { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }
    }
}
