using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class CardFaction
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int FactionId { get; set; }
        public Faction Faction { get; set; }
    }
}
