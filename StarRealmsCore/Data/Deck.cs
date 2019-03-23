using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class Deck
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int Type { get; set; }
        public ICollection<DeckCard> DeckCards { get; set; }
    }
}
