using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int DefaultQuantity { get; set; }
        public ICollection<DeckCard> DeckCards { get; set; }
        public ICollection<CardEffect> CardEffects { get; set; }
        public ICollection<FieldCard> FieldCards { get; set; }
        public ICollection<TradeCard> TradeCards { get; set; }
        public ICollection<CardFaction> CardFactions { get; set; } 
    }
}
