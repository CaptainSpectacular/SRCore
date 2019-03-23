using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class CardEffect
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int EffectId { get; set; }
        public Effect Effect { get; set; }
    }
}
