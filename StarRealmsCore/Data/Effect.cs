using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class Effect
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Quantity { get; set; }
        public bool IsFaction { get; set; }
        public bool IsScrap { get; set; }
        public bool IsBase { get; set; }
        public bool IsOutpost { get; set; }
        public ICollection<CardEffect> CardEffects { get; set; }
    }
}
