using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CardFaction> CardFactions { get; set; }
    }
}
